using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TOAU1_Simplecs
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		int countComponents = 1;
		int countGoods = 0;
		List<Product> products = new List<Product>();
		List<Component> components;
		StackPanel sp;
		double[] resultTabel;

		public MainWindow(StackPanel sp)
		{
			InitializeComponent();

			LoadStackPanel(sp);

			textBoxID.Text = (countGoods+1).ToString();
      }

		public MainWindow()
		{
			InitializeComponent();
			Summ.IsEnabled = false;
			Save.IsEnabled = false;
			textBoxLimit.IsEnabled = false;
			textBoxPrice.IsEnabled = false;
			buttonAdd.IsEnabled = false;
			buttonDel.IsEnabled = false;
			buttonLeft.IsEnabled = false;
			buttonRight.IsEnabled = false;
			Rep.IsEnabled = false;
		}

		private void LoadStackPanel(StackPanel sp)
		{
			this.sp = sp;
			components = new List<Component>();

			foreach(Grid child in sp.Children)
			{
				int limit = -1;
				string component = "";

				foreach(var children in child.Children)
				{
					if(children is Label)
					{
						component = ((Label)children).Content.ToString();
					}
					else if(children is TextBox)
					{
						if(!int.TryParse(((TextBox)children).Text, out limit))
						{
							limit = -1;
						}
					}
				}
				if(limit != -1 && component != "")
				{
					spLimitComponents.Children.Add(CreatGrid(limit, component, -1));
					countComponents++;
					components.Add(new Component(component.ToString(), limit, -1));
				}
			}
		}

		private Grid CreatGrid(int limit, string component, int count)
		{
			Grid grid = new Grid();

			Label label1 = new Label();
			label1.Name = "label1" + countComponents;
			label1.Margin = new Thickness(0, 0, 195, 0);
			label1.Content = component;

			Label label2 = new Label();
			label2.Name = "label2" + countComponents;
			label2.Margin = new Thickness(83, 0, 98, 0);
			label2.Content = limit;

			TextBox tb = new TextBox();
			tb.Name = "textBox1" + countComponents;
			tb.Margin = new Thickness(180, 1, 0, 1);
			if(count != -1)
				tb.Text = count.ToString();
			else
				tb.Text = "";

			grid.Children.Add(label1);
			grid.Children.Add(label2);
			grid.Children.Add(tb);

			return grid;
		}

		private void buttonAdd_Click(object sender, RoutedEventArgs e)
		{
			AddCountComponent();
			products.Add(new Product(textBoxID.Text, int.Parse(textBoxLimit.Text), int.Parse(textBoxPrice.Text), components));
			countGoods++;
			textBoxID.Text = (countGoods + 1).ToString();
			textBoxLimit.Text = "";
			textBoxPrice.Text = "";
			spLimitComponents.Children.RemoveRange(1, spLimitComponents.Children.Count);
			LoadStackPanel(sp);
      }

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void MenuItem_Click_1(object sender, RoutedEventArgs e)
		{
			TableComponents tc = new TableComponents();
			tc.Show();
			this.Close();
		}

		private void MenuItem_Click_2(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Ваша копия GoodSimpleX не является подлинной!", "Ошибка!");
		}

		private void MenuItem_Click_3(object sender, RoutedEventArgs e)
		{
			OpenFileDialog myDialog = new OpenFileDialog();
			myDialog.Filter = "(*.XML)|*.XML";
			myDialog.CheckFileExists = true;
			myDialog.Multiselect = false;
			myDialog.ShowDialog();
			products = new Serialize().DeserializeObject(myDialog.FileName);
			Summ.IsEnabled = true;
			Save.IsEnabled = true;
			textBoxLimit.IsEnabled = true;
			textBoxPrice.IsEnabled = true;
			buttonAdd.IsEnabled = true;
			buttonDel.IsEnabled = true;
			buttonLeft.IsEnabled = true;
			buttonRight.IsEnabled = true;
		}

		private void AddCountComponent()
		{
			int i = -1;
			foreach(Grid child in spLimitComponents.Children)
			{
				foreach(var children in child.Children)
				{
					if(children is TextBox)
					{
						components[i].Count = int.Parse(((TextBox)children).Text);
					}
				}
				i++;
			}
		}

		private void buttonDel_Click(object sender, RoutedEventArgs e)
		{
			Product productDel = null;
			foreach(Product product in products)
				if(product.ID == textBoxID.Text)
					productDel = product;

			if(productDel != null)
				products.Remove(productDel);

			textBoxLimit.Text = "";
			textBoxPrice.Text = "";
			spLimitComponents.Children.RemoveRange(1, spLimitComponents.Children.Count);
			LoadStackPanel(sp);
		}

		private void buttonLeft_Click(object sender, RoutedEventArgs e)
		{
			for(int i = 1; i < products.Count; i++)
			{
				if(products[i].ID == textBoxID.Text)
				{
					textBoxID.Text = products[i - 1].ID;
					textBoxLimit.Text = products[i - 1].Limit.ToString();
					textBoxPrice.Text = products[i - 1].Price.ToString();

					spLimitComponents.Children.RemoveRange(1, spLimitComponents.Children.Count);
					foreach(var component in products[i - 1].Components)
						spLimitComponents.Children.Add(CreatGrid(component.Limit, component.ID, component.Count));

					return;
				}
			}

			textBoxID.Text = products[products.Count - 1].ID;
			textBoxLimit.Text = products[products.Count - 1].Limit.ToString();
			textBoxPrice.Text = products[products.Count - 1].Price.ToString();

			spLimitComponents.Children.RemoveRange(1, spLimitComponents.Children.Count);
			foreach(var component in products[products.Count - 1].Components)
				spLimitComponents.Children.Add(CreatGrid(component.Limit, component.ID, component.Count));

		}

		private void buttonRight_Click(object sender, RoutedEventArgs e)
		{
			for(int i = 0; i < products.Count - 1; i++)
			{
				if(products[i].ID == textBoxID.Text)
				{
					textBoxID.Text = products[i + 1].ID;
					textBoxLimit.Text = products[i + 1].Limit.ToString();
					textBoxPrice.Text = products[i + 1].Price.ToString();

					spLimitComponents.Children.RemoveRange(1, spLimitComponents.Children.Count);
					foreach(var component in products[i + 1].Components)
						spLimitComponents.Children.Add(CreatGrid(component.Limit, component.ID, component.Count));


					return;
				}
			}

			textBoxID.Text = products[0].ID;
			textBoxLimit.Text = products[0].Limit.ToString();
			textBoxPrice.Text = products[0].Price.ToString();

			spLimitComponents.Children.RemoveRange(1, spLimitComponents.Children.Count);
			foreach(var component in products[0].Components)
				spLimitComponents.Children.Add(CreatGrid(component.Limit, component.ID, component.Count));
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog mySave = new SaveFileDialog();
			mySave.Filter = "(*.XML)|*.XML";
			mySave.ShowDialog();
			new Serialize().SerializeObject(mySave.FileName, products);
		}

		private void MenuItem_Click_4(object sender, RoutedEventArgs e)
		{
			Rep.IsEnabled = true;
			Table tabel = new Table(products);
			double[,] simplexTabel = tabel.SimplexTabel;

			resultTabel = SimplexMethod.GetResult(simplexTabel);//решение сиплекс-метододом

			new Result(resultTabel).Show();
		}

		private void MenuItem_Click_5(object sender, RoutedEventArgs e)
		{
			Report.DocRepopt(products, resultTabel);
		}

	}
}
