using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBuilder
{
    public class Link
    {
        public char Name { get; set; }
        public Node NodeIn { get; set; }
        public Node NodeOut { get; set; }
        public int Weight { get; set; }

        public Link(char Name, Node nodeOut, Node nodeIn)
        {
            this.Name = Name;
            this.NodeOut = nodeOut;
            this.NodeIn = nodeIn;
        }
        public Link(char Name, Node nodeOut, Node nodeIn, int weight)
        {
            this.Name = Name;
            this.NodeOut = nodeOut;
            this.NodeIn = nodeIn;
            this.Weight = weight;
        }

    }
}
