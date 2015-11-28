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
    public partial class Form_smegnost : Form
    {
        List<Node> nodes;
        List<Link> links;

        public Form_smegnost(List<Node> nodes, List<Link> links)
        {
            this.nodes = nodes;
            this.links = links;
            InitializeComponent();
        }

        private void Form_smegnost_Load(object sender, EventArgs e)
        {
            var matrixSmegnosty = CreatMatrixSmegnosty();

            if(Program.itOrientir)
                FillMatrixOrientir(matrixSmegnosty);
            else
                FillMatrixNotOrientir(matrixSmegnosty);

            PrintMatrixSmegnosty(matrixSmegnosty);
        }

        private int[][] CreatMatrixSmegnosty()
        {
            var matrixSmegnosty = new int[nodes.Count][];
            for (int i = 0; i < matrixSmegnosty.Length; i++)
                matrixSmegnosty[i] = new int[nodes.Count];
            return matrixSmegnosty;
        }

        private void PrintMatrixSmegnosty(int[][] matrixSmegnosty)
        {
            for (int i = 0; i < matrixSmegnosty.Length; i++)
            {
                string str = "";
                for (int j = 0; j < matrixSmegnosty[i].Length; j++)
                    str += string.Format("{0,3}", matrixSmegnosty[i][j].ToString());
                label_smegnost.Text += str + "\n";
            }
        }   
        
        private void FillMatrixOrientir(int[][] matrixSmegnosty)
        {
            foreach (var link in links)
                matrixSmegnosty[link.NodeOut.Number - 1][link.NodeIn.Number - 1] = 1;
        }

        private void FillMatrixNotOrientir(int[][] matrixSmegnosty)
        {
            foreach (var link in links)
            {
                matrixSmegnosty[link.NodeOut.Number - 1][link.NodeIn.Number - 1] = 1;
                matrixSmegnosty[link.NodeIn.Number - 1][link.NodeOut.Number - 1] = 1;
            }
        }
    }
}
