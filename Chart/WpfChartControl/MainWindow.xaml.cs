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


namespace WpfChartControl
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            showChart();
        }

        private void showChart()
        {

            List<KeyValuePair<string, int>> MyValue = new List<KeyValuePair<string, int>>();
            MyValue.Add(new KeyValuePair<string, int>("1", 20));
            MyValue.Add(new KeyValuePair<string, int>("2", 20));
            MyValue.Add(new KeyValuePair<string, int>("2", 50));
            MyValue.Add(new KeyValuePair<string, int>("3", 50));
            MyValue.Add(new KeyValuePair<string, int>("3", 30));
			   MyValue.Add(new KeyValuePair<string, int>("4", 30));


			line1.ItemsSource = MyValue;
        
            List<KeyValuePair<string, int>> MyValue1 = new List<KeyValuePair<string, int>>();
            MyValue1.Add(new KeyValuePair<string, int>("1", 5));
            MyValue1.Add(new KeyValuePair<string, int>("2", 10));
            MyValue1.Add(new KeyValuePair<string, int>("3", 15));
            MyValue1.Add(new KeyValuePair<string, int>("4", 20));
            MyValue1.Add(new KeyValuePair<string, int>("5", 25));

            line2.ItemsSource = MyValue1;
        }
    }
}
