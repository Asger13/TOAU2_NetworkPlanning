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
using Serialize;
using Microsoft.Win32;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using WpfChartControl;

namespace TOAU2_NetworkPlanning
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		List<Link> _links;
		List<Node> _nodes;
		double _sizeElips = 50;
		Point _pointMouseStart;
		Point _pointMouseFinish;
		char _nameLink = 'A';
		int _numNode = 0;
		List<Ellipse> _ellipses;
		List<LineArrow> _lines;
      List<TextBlock> _ltxb;
      List<TextBlock> _ltxb1;
		Node _nodeStart;       
      int elipcount=1;
		public MainWindow()
		{
			InitializeComponent();
            _ltxb1 = new List<TextBlock>();
            _ltxb = new List<TextBlock>();
			_links = new List<Link>();
			_nodes = new List<Node>();
			_ellipses = new List<Ellipse>();
			_lines = new List<LineArrow>();
			isSkpadSesurce.IsChecked = true;
      }

		private void Everistic_Click(object sender, RoutedEventArgs e)
		{
			ChartRes chart = new ChartRes();
			chart.Show();
		}

		private void Comby_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Rep_Click(object sender, RoutedEventArgs e)
		{

		}

		private void New_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveFile = new SaveFileDialog();
			saveFile.Filter = "(*.XML)|*.XML";
			saveFile.ShowDialog();
			Serialize<Link>.SerializeObject(saveFile.FileName, _links);
		}

		private void Upload_Click(object sender, RoutedEventArgs e)
		{

			OpenFileDialog openFile = new OpenFileDialog();
			openFile.Filter = "(*.XML)|*.XML";
			openFile.CheckFileExists = true;
			openFile.Multiselect = false;
			openFile.ShowDialog();
			_links = Serialize<Link>.DeserializeObject(openFile.FileName);
		}

		private void Close_Click(object sender, RoutedEventArgs e)
		{

		}

		private void canvas_MouseMove(object sender, MouseEventArgs e)
		{
			if(Mouse.LeftButton == MouseButtonState.Pressed)
			{
				Point newPoint = new Point(Mouse.GetPosition(canvas).X, Mouse.GetPosition(canvas).Y);
				_lines[_lines.Count - 1].SetPointLine(newPoint);
				RefreshCanvas();
			}
	}


		private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			_pointMouseStart = new Point(Mouse.GetPosition(canvas).X, Mouse.GetPosition(canvas).Y);

			if(Belongs(_pointMouseStart, 2))
			{
					if(Belongs(_pointMouseStart, 1))
					{
						_lines.Add(new LineArrow(_pointMouseStart, _pointMouseStart));
						RefreshCanvas();
					}
			}
			else
			{
				_nodeStart = new Node(_numNode, _pointMouseStart);
				_nodes.Add(_nodeStart);

				_ellipses.Add(CreateElips(_pointMouseStart));
				_lines.Add(new LineArrow(_pointMouseStart, _pointMouseStart));

                if (elipcount == 1)
                {
                    TextBlock ttxb = new TextBlock();
                    ttxb.Text = "1";
                    Canvas.SetLeft(ttxb, _pointMouseStart.X - 2);
                    Canvas.SetTop(ttxb, _pointMouseStart.Y - 8);
                    _ltxb.Add(ttxb);
                    elipcount++;

                }
				RefreshCanvas();

			}
		}

		private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			_pointMouseFinish = new Point(Mouse.GetPosition(canvas).X, Mouse.GetPosition(canvas).Y);

			if(Belongs(_pointMouseFinish, 2))
			{
				_lines[_lines.Count - 1].SetPointLine(Belongs(_pointMouseFinish).Point);

			}
			else
			{
				_nodes.Add(new Node(_numNode, _pointMouseFinish));

				_ellipses.Add(CreateElips(_pointMouseFinish));
                _ltxb.Add(createtxtblock());
                _ltxb1.Add(createtxtblock1());
			}

			_links.Add(new Link(_nameLink, _nodeStart, Belongs(_pointMouseFinish)));
            
			RefreshCanvas();

			spWorks.Children.Add(CreatGrid());

			_nameLink++;
            createtxtblock();
            
		}

		private Node Belongs(Point point)
		{
			Func<double, double, double,double, double, bool>
			InEllipse = (x1, x2, y1, y2, d) =>
			Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) <= Math.Pow(d, 2) ? true : false;

			foreach(Node node in _nodes)
				if(InEllipse(point.X, node.Point.X, point.Y, node.Point.Y, _sizeElips))
					return node;
			_numNode++;
			Node nodeNull = new Node(-1,point);
			return nodeNull;
		}

		private bool Belongs(Point point, double diametr)
		{
			Func<double, double, double,double, double, bool>
				InEllipse = (x1, x2, y1, y2, d) =>
				Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) <= Math.Pow(d/2*diametr, 2) ? true : false;

			foreach(Node node in _nodes)
				if(InEllipse(point.X, node.Point.X, point.Y, node.Point.Y, _sizeElips))
					return true;
			_numNode++;
			return false;
		}

        private TextBlock createtxtblock()
        {
            TextBlock ltxb = new TextBlock();
            ltxb.Text = _numNode.ToString();
            Canvas.SetLeft(ltxb, _pointMouseFinish.X - 2);
            Canvas.SetTop(ltxb, _pointMouseFinish.Y - 8);
            return ltxb;
        
        }
        private TextBlock createtxtblock1()
        {
            TextBlock ltxb1 = new TextBlock();
            ltxb1.Text = _nameLink.ToString();
            Canvas.SetLeft(ltxb1, (_pointMouseFinish.X + _pointMouseStart.X) / 2);
            Canvas.SetTop(ltxb1, (_pointMouseFinish.Y + _pointMouseStart.Y) / 2);
            return ltxb1;

        }
		//private void CreatLabelLink(Link link)
		//{
		//	Label label = new Label();

		//	label.Location = new Point((x + x1) / 2 - 20, (y + y1) / 2 + 20);
		//	label.Name = "label" + _nameLink;
		//	//label.Size = new Size(13, 13);
		//	label.Content = _nameLink.ToString();
		//	//pictureBox1.Controls.Add(label);
		//}
		private Ellipse CreateElips(Point point)
		{
            Ellipse elips = new Ellipse();
            elips.Fill = Brushes.Gold;
            elips.Width = elips.Height = _sizeElips;
            Canvas.SetLeft(elips, point.X - _sizeElips / 2);
            Canvas.SetTop(elips, point.Y - _sizeElips / 2);
			return elips;     
            
      }

		


		public void RefreshCanvas()
		{
			canvas.Children.Clear();

			foreach(var line in _lines)
			{
				canvas.Children.Add(line._lineMain);
				canvas.Children.Add(line._lineLeftArrow);
				canvas.Children.Add(line._lineRightArrow);
         }
         foreach (Ellipse ellipse in _ellipses)
            canvas.Children.Add(ellipse);               
         foreach (TextBlock txb in _ltxb)
            canvas.Children.Add(txb);
         foreach (TextBlock txb1 in _ltxb1)
             canvas.Children.Add(txb1);
            
		}

		private Grid CreatGrid()
		{
			Grid grid = new Grid();

			Label label = new Label();
			label.Margin = new Thickness(0, 0, 0, 0);
			label.FontSize = 16;
			label.Content = _nameLink;


			TextBox tbResource = new TextBox();
			tbResource.Margin = new Thickness(147, 1, 0, 1);
			tbResource.FontSize = 16;

			TextBox tbTime = new TextBox();
			tbTime.Margin = new Thickness(57, 1, 0, 1);
			tbTime.FontSize = 16;


			grid.Children.Add(label);
			grid.Children.Add(tbTime);
			grid.Children.Add(tbResource);

			return grid;
		}


	}
}
