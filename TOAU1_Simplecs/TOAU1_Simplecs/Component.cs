using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOAU1_Simplecs
{
    public class Component
    {
		public int Limit { get;	set; }
		public int Count { get; set; }
		public string ID { get; set; }

		public Component(string id, int limit, int count)
		{
			this.ID = id;
			this.Limit = limit;
			this.Count = count;
		}
		
		public Component() { }
    }
}
