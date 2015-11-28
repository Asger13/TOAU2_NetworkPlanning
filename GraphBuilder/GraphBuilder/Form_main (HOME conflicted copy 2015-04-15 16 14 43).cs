using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphBuilder
{
    public partial class Form_main : Form
    {
        List<Node> nodes = new List<Node>();
        List<Link> links = new List<Link>();
        char li = 'A';
        int num = 0;
        int group = 1;
        int groupPaint;
        bool itNode; //true - узел, false - звено.
        bool isClicked = false;
        bool isClickedDijkstra = false;
        bool isClickedGroup = false;
        bool isClickedZLP1 = false;
        bool isClickedZLP2 = false;
        List<Control> controlLabelList = new List<Control>();
        int[] matrixPath;
        List<int> pathsList = new List<int>(); 
        int x;
        int y;
        int x1;
        int y1;
        int zlpX1;
        int zlpX2;
        int zlpY1;
        int zlpY2;
        int r = 60;

        public Form_main()
        {
            InitializeComponent();
        }

        private void pictureBox_node_Click(object sender, EventArgs e)
        {
            pictureBox_node.BorderStyle = BorderStyle.Fixed3D;
            pictureBox_link.BorderStyle = BorderStyle.None;
            itNode = true;
        }

        private void pictureBox_link_Click(object sender, EventArgs e)
        {
            pictureBox_node.BorderStyle = BorderStyle.None;
            pictureBox_link.BorderStyle = BorderStyle.Fixed3D;
            itNode = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;

            if (isClickedZLP1 && !isClickedZLP2)
            {
                itNode = true;
                isClickedZLP2 = true;
                zlpX1 = e.X;
                zlpY1 = e.Y;
            }
            else if(isClickedZLP2)
            {
                zlpX2 = e.X;
                zlpY2 = e.Y;
                ZLP();
            }
            else if (isClickedDijkstra)
                Dijkstra(x, y);
            else if (!itNode)
                isClicked = true;
            
            isClickedDijkstra = false;
            label1.Text = "";

            isClickedGroup = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (itNode)
                pictureBox1.Invalidate();

            else if (!itNode && isClicked)
            {
                x1 = e.X;
                y1 = e.Y;
                pictureBox1.Invalidate();
            }
            if (Program.itOrientir)
                OpredelenieStepenyOrientir(e);
            else
                OpredelenieStepenyNotOrientir(e);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (itNode)
                SaveNode();
            else if (!itNode)
                SaveLink();

            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen;
            Pen pen1;
            Pen pen2;
            Pen penX;
            Pen penL;
            CreatPen(out pen, out pen1, out pen2, out penX, out penL);

            if (Program.itOrientir)
                PaintGraphO(e, pen, pen1, penX, penL);
            else
                PaintGraphN(e, pen1, pen2);
        }

        private void pictureBox_smegnost_Click(object sender, EventArgs e)
        {
            new Form_smegnost(nodes, links).ShowDialog();
        }

        private void pictureBox_incendentnoct_Click(object sender, EventArgs e)
        {
            new Form_incendentnost(nodes, links).ShowDialog();
        }

        private void pictureBox_elemCepi_Click(object sender, EventArgs e)
        {
            new Form_currentPath(nodes, links).ShowDialog();
        }

        private void pictureBox_hierarchy_Click(object sender, EventArgs e)
        {
            if(Program.itOrientir)
                new Form_hierarchy(nodes, links).ShowDialog();
        }

        private void pictureBox_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("студенты гр. ПИ-12\n\nЮлия Глазкова\nЮлия Голубева\nДаниил Дорохин\nАлексей Мельников\nНгуен Зоан Ань\nАртем Нечаев\nДаниил Шевцов", "Разработчики");
        }

        private void fkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Выберите вершину";
            isClickedDijkstra = true;
            itNode = true;
        }

        private void зЛПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isClickedZLP1 = true;
        }

        private void выделениеПодсистемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isClickedGroup = true;
            AllocatioSnubsystem();
            itNode = true;
        }

        private void OpredelenieStepenyNotOrientir(MouseEventArgs e)
        {
            foreach (var node in nodes)
            {
                if (Math.Pow((e.X - node.Point.X), 2) + Math.Pow((e.Y - node.Point.Y), 2) <= Math.Pow(r, 2))
                {
                    int stepen = 0;
                    foreach (var link in links)
                    {
                        if (link.NodeIn == node || link.NodeOut == node)
                            stepen++;
                    }

                    label_stepen.Text = stepen.ToString();
                }
            }
        }

        private void OpredelenieStepenyOrientir(MouseEventArgs e)
        {
            foreach (var node in nodes)
            {
                if (Math.Pow((e.X - node.Point.X), 2) + Math.Pow((e.Y - node.Point.Y), 2) <= Math.Pow(r, 2))
                {
                    int stepenI = 0;
                    int stepenO = 0;
                    foreach (var link in links)
                    {
                        if (link.NodeIn == node)
                            stepenI++;
                        if (link.NodeOut == node)
                            stepenO++;
                    }

                    label_stepen.Font = new Font("Microsoft Sans Serif", 40F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                    label_stepen.Text = "+" + stepenO.ToString() +"\n-" + stepenI.ToString();

                    if(isClickedGroup)
                        groupPaint = node.Group;
                }
            }
        }

        private void SaveLink()
        {
            isClicked = false;

            foreach (var node1 in nodes)
                if (Math.Pow((x - node1.Point.X - r / 2), 2) + Math.Pow((y - node1.Point.Y - r / 2), 2) <= Math.Pow(r, 2))
                    foreach (var node2 in nodes)
                        if (Math.Pow((x1 - node2.Point.X - r / 2), 2) + Math.Pow((y1 - node2.Point.Y - r / 2), 2) <= Math.Pow(r, 2))
                        {
                            bool flag = true;
                            foreach (var link in links)
                                if (Program.itOrientir)
                                {
                                    if (link.NodeOut == node1 && link.NodeIn == node2)
                                        flag = false;
                                }
                                else
                                {
                                    if (link.NodeOut == node1 && link.NodeIn == node2 || link.NodeOut == node2 && link.NodeIn == node1)
                                        flag = false;
                                }
                            if (flag)
                            {
                                new Form_weight(links, li, node1, node2).ShowDialog();
                                CreatLabelLink(links[links.Count - 1]);
                                li++;
                            }
                        }
        }

        private void SaveNode()
        {
            if (nodes.Count > 0)
            {
                bool flag = true;
                foreach (var node in nodes)
                    if (Math.Pow((x - node.Point.X), 2) + Math.Pow((y - node.Point.Y), 2) <= Math.Pow(2 * r, 2))
                    {
                        flag = false;
                        break;
                    }
                if (flag)
                {
                    num++;
                    nodes.Add(new Node(num, new Point(x, y)));
                    CreatLabelNode();
                }
            }
            else
            {
                num++;
                nodes.Add(new Node(num, new Point(x, y)));
                CreatLabelNode();
            }
        }

        private void CreatLabelWeightPath(Node node)
        {
            var label = new Label();
            label.AutoSize = true;
            label.Location = new Point(node.Point.X - 20, node.Point.Y - 15);
            label.Name = "label" + num + node.Path;
            label.Size = new Size(13, 13);
            if (node.Path == 1000000000)
                label.Text = "∞";
            else
                label.Text = node.Path.ToString();
            label.ForeColor = Color.Aqua;
            label.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            pictureBox1.Controls.Add(label);
            controlLabelList.Add(label);
        }

        private void CreatLabelNode()
        {
            var label = new Label();
            label.AutoSize = true;
            label.Location = new Point(x - r / 2, y - r / 2);
            label.Name = "label" + num;
            label.Size = new Size(13, 13);
            label.Text = num.ToString();
            label.ForeColor = Color.Green;
            label.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            pictureBox1.Controls.Add(label);
        }

        private void CreatLabelLink(Link link)
        {
            var label = new Label();
            label.AutoSize = true;
            label.Location = new Point((x + x1) / 2-20, (y + y1) / 2+20);
            label.Name = "label" + li;
            label.Size = new Size(13, 13);
            label.Text = li.ToString() + " = " + link.Weight.ToString();
            label.ForeColor = Color.Red;
            label.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            pictureBox1.Controls.Add(label);
        }

        private static void CreatPen(out Pen pen, out Pen pen1, out Pen pen2, out Pen penX, out Pen penL)
        {
            pen = new Pen(Color.DarkRed, 6);
            pen.EndCap = LineCap.ArrowAnchor;
            pen1 = new Pen(Color.Black, 1);
            pen2 = new Pen(Color.Black, 3);
            penX = new Pen(Color.DarkOrange, 7);
            penL = new Pen(Color.Aqua, 7);
            penL.EndCap = LineCap.ArrowAnchor;
        }

        private void PaintGraphN(PaintEventArgs e, Pen pen1, Pen pen2)
        {
            if (isClicked)
                e.Graphics.DrawLine(pen2, new Point(x, y), new Point(x1, y1));

            foreach (var node in nodes)
                e.Graphics.DrawEllipse(pen1, node.Point.X - r / 2, node.Point.Y - r / 2, r, r);

            foreach (var link in links)
                e.Graphics.DrawLine(pen2, link.NodeOut.Point, link.NodeIn.Point);
        }

        private void PaintGraphO(PaintEventArgs e, Pen pen, Pen pen1, Pen penX, Pen penL)
        {
            if (isClicked)
                e.Graphics.DrawLine(pen, new Point(x, y), new Point(x1, y1));
            foreach (var node in nodes)
            {
                Pen penEl = pen1;
                if (isClickedGroup)
                {
                    if (node.Group == groupPaint)
                        penEl = penX;
                    else
                        penEl = pen1;
                }

                e.Graphics.DrawEllipse(penEl, node.Point.X - r / 2, node.Point.Y - r / 2, r, r);
            }

            foreach (var link in links)
            {
                Pen penEl = pen;

                if (matrixPath != null)
                {
                    for (int j = 0; j < matrixPath.Length; j++)
                    {
                        if (matrixPath[link.NodeIn.Number] == link.NodeOut.Number && pathsList.Contains(link.NodeIn.Number))
                        {
                            penEl = penL;
                            break;
                        }
                        else
                            penEl = pen;
                    }
                }
                
                e.Graphics.DrawLine(pen1, link.NodeOut.Point, link.NodeIn.Point);
                e.Graphics.DrawLine(penEl,
                    link.NodeOut.Point.X,
                    link.NodeOut.Point.Y,
                    (link.NodeOut.Point.X + link.NodeIn.Point.X) / 2,
                    (link.NodeOut.Point.Y + link.NodeIn.Point.Y) / 2
                );
                //e.Graphics.DrawBezier(pen,
                //    link.NodeOut.Point
                //    , new Point((link.NodeOut.Point.X + link.NodeIn.Point.X) / 3, (link.NodeOut.Point.Y + link.NodeIn.Point.Y) / 2)
                //    , new Point((link.NodeOut.Point.X + link.NodeIn.Point.X) / 2, (link.NodeOut.Point.Y + link.NodeIn.Point.Y) / 3)
                //    , link.NodeIn.Point);
            }

        }

        private void ZLP()
        {
            matrixPath = new int[nodes.Count + 1];

            Dijkstra(zlpX1, zlpY1);

            pathsList.Clear();
            foreach (var node in nodes)
                if (isClickedZLP2 && Math.Pow((zlpX2 - node.Point.X - r / 2), 2) + Math.Pow((zlpY2 - node.Point.Y - r / 2), 2) <= Math.Pow(r, 2))
                    GetElementMatrix(node.Number, matrixPath);

            foreach (var lab in controlLabelList)
                pictureBox1.Controls.Remove(lab);
            foreach (var node in nodes)
                if (Math.Pow((zlpX2 - node.Point.X - r / 2), 2) + Math.Pow((zlpY2 - node.Point.Y - r / 2), 2) <= Math.Pow(r, 2))
                    CreatLabelWeightPath(node);

            isClickedZLP2 = false;
        }

        private void Dijkstra(int x, int y)
        {
            foreach (var lab in controlLabelList)
                pictureBox1.Controls.Remove(lab);
            Refresh();
            foreach (var node in nodes)
            {
                node.Visits = false;
                node.Path = 1000000000;
                node.NodeListIn.Clear();
                node.NodeListOut.Clear();
            }

            new Form_hierarchy(nodes, links).FillIO();

            foreach(var node in nodes)
                if (Math.Pow((x - node.Point.X - r / 2), 2) + Math.Pow((y - node.Point.Y - r / 2), 2) <= Math.Pow(r, 2))
                    node.Path = 0;

            int chetVisitsNode = 0;
            int qwe = 0;
            while (chetVisitsNode < nodes.Count)
            {
                if (qwe == nodes.Count)
                    break;
                int minPathNode = 0;
                if (!nodes[qwe].Visits)
                {
                    minPathNode = nodes[qwe].Path;
                }
                else
                {
                    qwe++;
                    continue;
                }

                foreach (var node in nodes)
                    if (minPathNode > node.Path && !node.Visits)
                        minPathNode = node.Path;

                foreach (var node in nodes)
                {
                    if (node.Path == minPathNode)
                    {
                        foreach (var nodeOut in node.NodeListOut)
                        {
                            foreach (var link in links)
                            {
                                if (link.NodeOut == node
                                    && link.NodeIn == nodeOut
                                    && nodeOut.Path > node.Path + link.Weight)
                                {
                                    nodeOut.Path = node.Path + link.Weight;
                                    matrixPath[link.NodeIn.Number] = link.NodeOut.Number;
                                }
                            }
                        }
                        node.Visits = true;
                        chetVisitsNode++;
                    }
                }
            }
            foreach (var node in nodes)
                CreatLabelWeightPath(node);
        }

        private int GetElementMatrix(int i, int[] matrixPath)
        {
            pathsList.Add(i);
            foreach (var node in nodes)
            {
                if (Math.Pow((zlpX1 - node.Point.X - r / 2), 2) + Math.Pow((zlpY1 - node.Point.Y - r / 2), 2) <= Math.Pow(r, 2))
                    if (i == node.Number)
                        return matrixPath[i];
            }
            return GetElementMatrix(matrixPath[i], matrixPath);
            
        }

        private void AllocatioSnubsystem()
        {
            foreach (var node in nodes)
            {
                node.Group = 0;
                node.NodeListIn.Clear();
                node.NodeListOut.Clear();
            }

            new Form_hierarchy(nodes, links).FillIO();
            foreach (var node in nodes)
            {
                if(ObhodNodes(node))
                    group++;
            }

            foreach (var lab in controlLabelList)
                pictureBox1.Controls.Remove(lab);
            Refresh();
        }

        private bool ObhodNodes(Node node)
        {
            if (node.Group != 0)
                return false;

            List<int> R = new List<int>();
            List<int> Q = new List<int>();
            Dijkstra(node.Point.X, node.Point.Y);

            foreach (var node1 in nodes)
            {
                if (node1.Path < 1000000000)
                    R.Add(node1.Number);
            }
            
            foreach(var node1 in nodes)
            {
                Dijkstra(node1.Point.X, node1.Point.Y);
                if (node.Path < 1000000000)
                    Q.Add(node1.Number);
            }

            foreach(int i in R)
            {
                if (Q.Contains(i) && nodes[i-1].Group == 0)
                    nodes[i-1].Group = group;
            }

            return true;
        }

        private void алгоритмФлойдаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var lab in controlLabelList)
                pictureBox1.Controls.Remove(lab);
            Refresh();

            int n = nodes.Count;
            int[,] MatrixVes = new int[n, n];

            foreach (var link in links)
                MatrixVes[link.NodeIn.Number - 1, link.NodeIn.Number - 1] = link.Weight;

            for (int k = 0; k < n; k++)
                for (int i = 0; i < n; i++)
                    if (MatrixVes[k, i] == 0)
                        MatrixVes[k, i] = 1000000000;

            for (int k=0;k<n;k++)
                for (int i=0;i<n;i++)
                    for (int j=0;j<n;j++)
                        if (MatrixVes[i, j] != 1000000000)
                        {
                            if (MatrixVes[i, j] > (MatrixVes[i, k] + MatrixVes[k, j]))
                                MatrixVes[i, j] = MatrixVes[i, k] + MatrixVes[k, j];
                        }

            for (int k = 0; k < n; k++)
                for (int i = 0; i < n; i++)
                    if (MatrixVes[k, i] < 1000000000)
                        nodes[k].Path = MatrixVes[k, i];

            foreach (var node in nodes)
                CreatLabelWeightPath(node);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
           // isClickedZLP2 = false;

        }
    }
}
