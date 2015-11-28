using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphBuilder
{
    public partial class Form_currentPath : Form
    {
        List<Node> nodes;
        List<Link> links;

        public Form_currentPath(List<Node> nodes, List<Link> links)
        {
            InitializeComponent();
            this.nodes = nodes;
            this.links = links;
        }

        private void CurrentPath_Load(object sender, EventArgs e)
        {
            ElementarniePath();
        }

        /// <summary>
        /// Метод анализа простых путей
        /// </summary>
        private void FindPath()
        {
            throw new NotImplementedException();
        }

        private void ElementarniePath()
        {
            var matrixSmegnosty = new int[nodes.Count, nodes.Count];

            foreach (var link in links)
            {
                matrixSmegnosty[link.NodeOut.Number - 1, link.NodeIn.Number - 1] = 1;
                if (!Program.itOrientir)
                    matrixSmegnosty[link.NodeIn.Number - 1, link.NodeOut.Number - 1] = 1;
            }

            List<List<int>> listPaths = new List<List<int>>();

            for (int i = 0; i < Math.Sqrt(matrixSmegnosty.Length); ++i)
            {
                List<int> path = new List<int>();
                path.Add(i);
                Obhod(matrixSmegnosty, i, listPaths, path);
            }

            for (int i = 0; i < listPaths.Count; i++)
            {
                for (int j = 0; j < listPaths[i].Count; j++)
                {
                    label_path.Text += (1 + listPaths[i][j]).ToString();

                    if (j < listPaths[i].Count - 1)
                        label_path.Text += " -> ";
                    else
                        label_path.Text += "\n";
                }
            }
        }

        public static void Obhod(int[,] matr, int current, List<List<int>> paths, List<int> currentPath)
        {
            for (int i = 0; i < Math.Sqrt(matr.Length); ++i)
            {
                if (matr[current, i] == 1)
                {
                    if (currentPath.Find(new Predicate<int>((some) => { return some == i ? true : false; })) == i)
                    {
                        //currentPath.Add(i);
                        continue;
                    }
                    else
                    {
                        currentPath.Add(i);

                        Obhod(matr, i, paths, currentPath);

                        paths.Add(currentPath.ToList());

                        currentPath.Remove(i);
                    }
                }
            }
        }
    }
}
