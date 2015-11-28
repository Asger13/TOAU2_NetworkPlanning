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
    public partial class Form_weight : Form
    {
        List<Link> links;
        char NameLink;
        Node nodeOut;
        Node nodeIn;

        public Form_weight(List<Link> links, char NameLink, Node nodeOut, Node nodeIn)
        {
            InitializeComponent();
            this.links = links;
            this.NameLink = NameLink;
            this.nodeIn = nodeIn;
            this.nodeOut = nodeOut;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "0";
            links.Add(new Link(NameLink, nodeOut, nodeIn, int.Parse(textBox1.Text)));

            this.Close();
        }
    }
}
