using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TOAU1_Simplecs
{
	/// <summary>
	/// Логика взаимодействия для Result.xaml
	/// </summary>
	public partial class Result : Window
	{
		public Result(double[] tabel)
		{
			InitializeComponent();

			labelMaxIncome.Content += tabel[0].ToString();

			for(int i = 1; i < tabel.Length; i++)
				spResult.Children.Add(CreatLabel(tabel[i], i));
		}

		public Label CreatLabel(double elem, int i)
		{
			Label label1 = new Label();
			label1.Content = i + "                                          " + elem;
			return label1;
		}
	}
}
