using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOAU1_Simplecs
{
	public class Product
	{
		public List<Component> Components { get; set; }
		public int Limit { get; set; }
		public int Price { get; set; }
		public string ID { get; set; }

		public Product(string id, int limit, int price, List<Component> components)
		{
			this.ID = id;
			this.Limit = limit;
			this.Price = price;
			this.Components = components;
      }

		public Product() { }
	}
}
