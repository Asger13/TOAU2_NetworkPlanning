using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TOAU2_NetworkPlanning
{
    public class Node
    {
        public int Number { get; set; }
        public Point Point { get; set; }
			public int Path { get; set; }
			public bool Visits { get; set; }
			public int Group { get; set; }
			public List<Node> NodeListIn = new List<Node>();
			public List<Node> NodeListOut = new List<Node>();

		public Node(int number, Point point)
        {
            Number = number;
            Point = point;
        }
		public void SetNodesOut(Node NodeOut)
		{
			this.NodeListOut.Add(NodeOut);
		}

		public void SetNodesIn(Node NodeIn)
		{
			this.NodeListIn.Add(NodeIn);
		}

	}
}
