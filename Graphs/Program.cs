﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph myGraph = new Graph();

            myGraph.DepthFirst("Bedroom");
        }
    }
}
