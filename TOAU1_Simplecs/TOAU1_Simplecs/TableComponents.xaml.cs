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
	/// Логика взаимодействия для TableComponents.xaml
	/// </summary>
	public partial class TableComponents : Window
	{
		int countComponents = 3;

		public TableComponents()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			string error = TrueTextBox();
			if(error == "")
			{
				if(MyStackPanel == null)
				{
					new MainWindow().Show();
				}
            MainWindow mw = new MainWindow(MyStackPanel);
				mw.Show();
				this.Close();
			}
			else
			{
				MessageBox.Show(error, "Ошибка");
			}
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			
			MyStackPanel.Children.Add(CreatGrid());
			countComponents++;
		}

		private string TrueTextBox()
		{
			string er1 = "";
			string er2 = "";
			foreach(Grid grid in MyStackPanel.Children)
			{
				foreach(var child in grid.Children)
				{
					int i;
					if(child is TextBox)
					{
						TextBox tb = (TextBox)child;
						if(tb.Text == "")
						{
							er1 = "Остались пустые поля\n";
						}
						else if(!int.TryParse(tb.Text, out i) || i < 0)
						{
							er2 = "Значение полей может принимать вид от 0 до " + int.MaxValue;
						}
					}
				}
			}
			return er1 + er2;
		}

		private Grid CreatGrid()
		{
			Grid grid = new Grid();

			Label label = new Label();
			label.Name = "label1" + countComponents;
			label.Margin = new Thickness(0, 0, 222, 0);
			label.FontSize = 16;
			label.Content = countComponents;

			TextBox tb = new TextBox();
			tb.Name = "textBox1" + countComponents;
			tb.Margin = new Thickness(132, 1, 0, 1);
			tb.FontSize = 16;

			grid.Children.Add(label);
			grid.Children.Add(tb);

			return grid;
		}

	}
}
