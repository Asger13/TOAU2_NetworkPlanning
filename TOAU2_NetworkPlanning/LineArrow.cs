using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TOAU2_NetworkPlanning
{
	class LineArrow
	{
		double _sizeLine = 3;
		TArrow TargetArrow = new TArrow();
		Point _pointStart;

		public Line _lineMain { get; set; }
		public Line _lineLeftArrow { get; set; }
		public Line _lineRightArrow { get; set; }
		

		public LineArrow(Point pointStart, Point pointFinish)
		{
			_pointStart = pointStart;
			GetArrow(pointStart, pointFinish);
			_lineMain = CreateLine(pointStart, pointFinish);
			_lineLeftArrow = CreateLine(TargetArrow.center, TargetArrow.left);
			_lineRightArrow = CreateLine(TargetArrow.center, TargetArrow.right);

		}

		public void SetPointLine(Point point)
		{

			GetArrow(_pointStart, point);
			_lineMain = CreateLine(_pointStart, point);
			_lineLeftArrow = CreateLine(TargetArrow.center, TargetArrow.left);
			_lineRightArrow = CreateLine(TargetArrow.center, TargetArrow.right);
		}

		private Line CreateLine(Point pointStart, Point pointFinish)
		{
			Line myLine = new Line();
			myLine.Stroke = Brushes.LightSteelBlue;
			myLine.X1 = pointStart.X;
			myLine.Y1 = pointStart.Y;
			myLine.X2 = pointFinish.X;
			myLine.Y2 = pointFinish.Y;
			myLine.StrokeThickness = _sizeLine;

			return myLine;
		}

		private void GetArrow(Point starting, Point ending)
		{
			Point catal;
			double dotrad = new double();
			double AB, AC, AH, AL, CK, CB;

			catal = new Point(starting.X, ending.Y);    // промежуточная точка
																	  // = sqrt(sqr(y2 - y1) + sqr(x2 - x1))
			AB = Math.Sqrt(Math.Pow((ending.Y - starting.Y), 2) + Math.Pow((ending.X - starting.X), 2));
			AC = Math.Sqrt(Math.Pow((ending.Y - starting.Y), 2) + Math.Pow((starting.X - starting.X), 2));
			AH = dotrad;
			AL = AC / (AB / AH);
			CB = Math.Sqrt(Math.Pow((ending.Y - ending.Y), 2) + Math.Pow((ending.X - starting.X), 2));
			CK = CB / (AB / AH);
			// targetdot = ((starting.X + AL),(ending.Y+CK);
			if(ending.X == starting.X)
				TargetArrow.center = new Point((Convert.ToInt32(starting.X)), Convert.ToInt32(ending.Y + CK));

			if(ending.Y == starting.Y)
				TargetArrow.center = new Point((Convert.ToInt32(starting.X + AL)), Convert.ToInt32(ending.Y));

			else
				TargetArrow.center = new Point((Convert.ToInt32(starting.X + AL)), Convert.ToInt32(ending.Y + CK));

		}

	}
}
