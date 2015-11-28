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
    public partial class Form_incendentnost : Form
    {
        List<Node> nodes;
        List<Link> links;

        public Form_incendentnost(List<Node> nodes, List<Link> links)
        {
            InitializeComponent();
            this.nodes = nodes;
            this.links = links;
        }

        private void Form_incendentnost_Load(object sender, EventArgs e)
        {
            var matrixIncendentnosty = CreatMatrixIncendentnosty();

            if (Program.itOrientir)
                FillMatrixIncendentnosty(matrixIncendentnosty, -1);
            else
                FillMatrixIncendentnosty(matrixIncendentnosty, 1);

            PrintMatrixIncendentnosty(matrixIncendentnosty);
        }

        private int[][] CreatMatrixIncendentnosty()
        {
            var matrixIncendentnosty = new int[nodes.Count][];
            for (int i = 0; i < matrixIncendentnosty.Length; i++)
                matrixIncendentnosty[i] = new int[links.Count];
            return matrixIncendentnosty;
        }

        private void PrintMatrixIncendentnosty(int[][] matrixIncendentnosty)
        {
            string st = "";
            foreach (var link in links)
                st += string.Format("{0,3}", link.Name);
            label_incendentnost.Text = st + "\n";

            for (int i = 0; i < matrixIncendentnosty.Length; i++)
            {
                string str = "";
                for (int j = 0; j < matrixIncendentnosty[i].Length; j++)
                {
                    str += string.Format("{0,3}",  matrixIncendentnosty[i][j].ToString());
                }
                label_incendentnost.Text += str + "\n";
            }
        }

        private void FillMatrixIncendentnosty(int[][] matrixIncendentnosty, int orientir)
        {
            int k = 0;
            foreach (var link in links)
            {
                matrixIncendentnosty[link.NodeOut.Number - 1][k] = 1;
                matrixIncendentnosty[link.NodeIn.Number - 1][k] = orientir;
                k++;
            }
        }
    }
}
