using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Vertex
    {
        private string name;
        private bool visited;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }

        public Vertex(string name)
        {
            this.name = name;
            visited = false;
        }
    }
}
