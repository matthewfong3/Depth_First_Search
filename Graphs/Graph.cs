using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Graph
    {
        int[,] adjMatrix = new int[5, 5]
        {  //LR BR DN KI BA
            {0, 1, 1, 0, 0 }, // living room 0
            {1, 0, 0, 0, 1 }, // bedroom 1
            {1, 0, 0, 1, 0 }, // dining room 2
            {0, 0, 1, 0, 0 }, // kitchen 3
            {0, 1, 0, 0, 0 }  // bathroom 4
        };

        Dictionary<string, Vertex> layout;
        List<Vertex> vertices;

        public Graph()
        {
            Vertex livingRoom = new Vertex("Living Room");
            Vertex bedroom = new Vertex("Bedroom");
            Vertex diningRoom = new Vertex("Dining Room");
            Vertex kitchen = new Vertex("Kitchen");
            Vertex bathroom = new Vertex("Bathroom");

            layout = new Dictionary<string, Vertex>();
            layout["Living Room"] = livingRoom;
            layout["Bedroom"] = bedroom;
            layout["Dining Room"] = diningRoom;
            layout["Kitchen"] = kitchen;
            layout["Bathroom"] = bathroom;

            vertices = new List<Vertex>();
            vertices.Add(livingRoom);
            vertices.Add(bedroom);
            vertices.Add(diningRoom);
            vertices.Add(kitchen);
            vertices.Add(bathroom);
        }

        public void Reset()
        {
            foreach(Vertex v in vertices)
            {
                v.Visited = false;
            }
        }

        public Vertex GetUnvisitedNeighbor(string name)
        {
            Vertex v = layout[name];

            if (v != null)
            {
                int i = vertices.IndexOf(v);
                int length = adjMatrix.GetLength(1);

                for(int j = 0; j < length; j++)
                {
                    if (adjMatrix[i, j] == 1 && !vertices[j].Visited)
                    {
                        return vertices[j];
                    }
                }
                return null;
            }
            return null;
        }

        public void DepthFirst(string name)
        {
            Vertex v = layout[name];

            if (v != null)
            {
                Reset();

                Stack<Vertex> currStack = new Stack<Vertex>();

                Console.WriteLine(v.Name);
                currStack.Push(v);
                v.Visited = true;

                while (currStack.Count > 0)
                {
                    Vertex unvisited = GetUnvisitedNeighbor(currStack.Peek().Name);

                    if (unvisited != null)
                    {
                        Console.WriteLine(unvisited.Name);
                        currStack.Push(unvisited);
                        unvisited.Visited = true;
                    }
                    else
                    {
                        currStack.Pop();
                    }
                }
            }
            else
            {
                Console.WriteLine("Error! Does not exist");
                return;
            }
        }
    }
}
