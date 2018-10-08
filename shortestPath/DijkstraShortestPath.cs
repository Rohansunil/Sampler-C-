using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class DijkstraShortestPath
    {
        int size;
        int[] dist;
        bool[] sptSet;
        int[] parent;
        int[,] graph;

        public DijkstraShortestPath(int size, int[,] graph)
        {
            this.size = size;
            dist = new int[size];
            sptSet = new bool[size];
            parent = new int[size];
            this.graph = graph;
        }
        int minDistance()
        {
            // Initialize min value 
            int minValue = Int32.MaxValue, minIndex = -1;

            for (int v = 0; v < size; v++)
            {
                if (sptSet[v] == false && dist[v] <= minValue)
                {
                    minValue = dist[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        void printPath(int j)
        {

            // Base Case : If j is source 
            if (parent[j] == -1)
                return;

            printPath(parent[j]);

            Console.WriteLine(j);
        }

        int printSolution()
        {
            int src = 0;
            Console.WriteLine("Vertex\t Distance\tPath");
            for (int i = 1; i < size; i++)
            {
                Console.WriteLine("\n"+src+" -> "+i+" \t\t "+dist[i]+"\t\t"+src);
                printPath(i);
            }
            return 1;
        }

        public void dijkstra(int src)
        {
            for (int i = 0; i < size; i++)
            {
                parent[i] = -1;
                dist[i] = Int32.MaxValue;
                sptSet[i] = false;
            }
            dist[src] = 0;
            for (int count = 0; count < size - 1; count++)
            {
                int u = minDistance();
                sptSet[u] = true;
                for (int v = 0; v < size; v++)
                {
                    if (!sptSet[v] && graph[u,v] != 0 && (dist[u] + graph[u,v]) < dist[v])
                    {
                        parent[v] = u;
                        dist[v] = dist[u] + graph[u,v];
                    }
                }
                printSolution();
            }

        }
    }
}
