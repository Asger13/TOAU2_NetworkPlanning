using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOAU2_NetworkPlanning
{
    public class Link
    {
      public char Name { get; set; }
      public Node NodeIn { get; set; }
      public Node NodeOut { get; set; }
      public double CountTime { get; set; }
		public double CountResurses { get; set; }

      public Link(char name, Node nodeOut, Node nodeIn)
      {
         Name = name;
         NodeOut = nodeOut;
         NodeIn = nodeIn;
      }
      public Link(char name, Node nodeOut, Node nodeIn, double countTime, double countResurses)
			:this(name, nodeOut, nodeIn)
      {
			CountTime = countTime;
			CountResurses = countResurses;
      }

    }
}
