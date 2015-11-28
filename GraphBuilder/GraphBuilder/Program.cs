using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphBuilder
{
    static class Program
    {
        /// <summary>
        /// true - ориентрованный, false - неориентрованный.
        /// </summary>
        public static bool itOrientir;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_selection());
        }
    }
}
