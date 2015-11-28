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
    public partial class Form_selection : Form
    {
        public Form_selection()
        {
            InitializeComponent();
        }

        private void button_orientir_Click(object sender, EventArgs e)
        {
            Program.itOrientir = true;
            ShowMain();
        }

        private void button_notOrientir_Click(object sender, EventArgs e)
        {
            Program.itOrientir = false;
            ShowMain();
        }

        private void ShowMain()
        {
            this.Hide();
            new Form_main().ShowDialog();
            this.Close();
        }
    }
}
