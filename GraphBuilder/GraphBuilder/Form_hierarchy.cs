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
    public partial class Form_hierarchy : Form
    {
        int r = 60;
        int dx = 200;
        int dy = 100;
        List<Node> nodes = new List<Node>();
        List<Link> links = new List<Link>();
        int schetNode = 0;
        List<List<Node>> hierarchyList = new List<List<Node>>();

        public Form_hierarchy(List<Node> _nodes, List<Link> _links)
        {
            InitializeComponent();
            foreach (var node in _nodes)
                nodes.Add(node);
            foreach (var link in _links)
                links.Add(link);
        }

        private void Form_hierarchy_Load(object sender, EventArgs e)
        {
            FillIO();
            ZaseliCokol();
            
            while(schetNode < nodes.Count)
                ZaseliFloor(hierarchyList.Count-1);
        }

        private void ZaseliFloor(int numFloor)
        {
            var floor = new List<Node>();
            for (int numApartment = 0; numApartment < hierarchyList[numFloor].Count; numApartment++)
            {
                for (int numNodeOut = 0; numNodeOut < hierarchyList[numFloor][numApartment].NodeListOut.Count; numNodeOut++)
                {
                    var nodeTemp = hierarchyList[numFloor][numApartment].NodeListOut[numNodeOut];
                    if (SearchNode(numFloor, nodeTemp))
                    {
                        if (!floor.Contains(nodeTemp))
                        {
                            floor.Add(nodeTemp);
                            schetNode++;
                        }
                    }
                }
            }
            if(floor.Count != 0)
                hierarchyList.Add(floor);
        }

        private bool SearchNode(int numFloor, Node nodeTemp)
        {
            int i = 0;
            foreach (var node in nodeTemp.NodeListIn)
            {
                int j = numFloor;
                for (; j >= 0; j--)
                {
                    for (int numApartment = 0; numApartment < hierarchyList[j].Count; numApartment++)
                    {
                        if (node == hierarchyList[j][numApartment])
                        {
                            i++;
                        }
                    }
                }
            }
            if (i == nodeTemp.NodeListIn.Count)
                return true;
            else
                return false;
        }

        public void FillIO()
        {
            foreach (var link in links)
                foreach (var node in nodes)
                {
                    if (link.NodeOut == node)
                        node.SetNodesOut(link.NodeIn);
                    if (link.NodeIn == node)
                        node.SetNodesIn(link.NodeOut);
                }
        }

        private void ZaseliCokol()
        {
            var floor = new List<Node>();
            foreach (var node in nodes)
            {
                if (node.NodeListIn.Count == 0)
                {
                    floor.Add(node);
                    schetNode++;
                }
            }
            hierarchyList.Add(floor);
        }

        private void GetPoint()
        {
            int i = 0;
            for(int numFloor = 0; numFloor < hierarchyList.Count; numFloor++)
            {
                for(int numApartment = 0; numApartment < hierarchyList[numFloor].Count; numApartment++)
                {
                    hierarchyList[numFloor][numApartment].Point = new Point(numFloor * dx, numApartment * dy + i);
                    i += 15;
                }
            }
        }


        private void pictureBox_hierarchy_Paint(object sender, PaintEventArgs e)
        {
            Pen pen;
            Pen pen1;
            Pen pen2;
            CreatPen(out pen, out pen1, out pen2);
            GetPoint();
            for(int numFloor = 0; numFloor < hierarchyList.Count; numFloor++)
            {
                for(int numApartment = 0; numApartment < hierarchyList[numFloor].Count; numApartment++)
                {
                    Node node = hierarchyList[numFloor][numApartment];
                    foreach (var nodel in node.NodeListOut)
                    {
                        e.Graphics.DrawLine(pen1, node.Point.X + r / 2, node.Point.Y + r / 2, nodel.Point.X + r / 2, nodel.Point.Y + r / 2);
                        e.Graphics.DrawLine(pen,
                            node.Point.X + r / 2,
                            node.Point.Y + r / 2,
                            ((node.Point.X + r / 2) + (nodel.Point.X + r / 2)) / 2,
                            (node.Point.Y + r / 2 + nodel.Point.Y + r / 2) / 2
                        );
                    }
                    e.Graphics.DrawEllipse(pen1, node.Point.X, node.Point.Y, r, r);
                    CreatLabelNode(node);
                }
            }

        }

        private static void CreatPen(out Pen pen, out Pen pen1, out Pen pen2)
        {
            pen = new Pen(Color.Red, 6);
            pen.EndCap = LineCap.ArrowAnchor;
            pen1 = new Pen(Color.Black, 1);
            pen2 = new Pen(Color.Black, 3);
        }
        private void CreatLabelNode(Node node)
        {
            var label = new Label();
            label.AutoSize = true;
            label.Location = node.Point;
            label.Name = "label" + node.Number;
            label.Size = new Size(13, 13);
            label.Text = node.Number.ToString();
            label.ForeColor = Color.Green;
            label.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            pictureBox_hierarchy.Controls.Add(label);
        }

    }
}
