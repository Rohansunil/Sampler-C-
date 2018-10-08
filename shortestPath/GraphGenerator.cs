using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class GraphGenerator
    {
        public int[,] GraphGenerate(int size)
        {
            Random randomGenerate = new Random();
            int weight;
            int[,] graph = new int[size, size];
            for(int i = 0, k = 0,j; i < size; i++, k++)
            {
                j = k;
                for(; j < size; j++)
                {
                    if(i == j)
                    {
                        graph[i, j] = -1;
                    }
                    else
                    {
                        weight = randomGenerate.Next(-1,10);
                        if (weight == 0)
                        {
                            weight = -1;
                        }
                        graph[i, j] = weight;
                        graph[j, i] = weight;
                    }
                }
            }
            return graph;
        }
    }
}
