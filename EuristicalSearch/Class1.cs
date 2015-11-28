using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TOAU2_NetworkPlanning;

namespace EuristicalSearch
{
	public class Class1
	{
		List<Link> _links;
		double _resourcesTolal;

		public Class1(List<Link> links, double resourcesTolal)
		{
			_links = links;
			_resourcesTolal = resourcesTolal;

		}
	}
}
