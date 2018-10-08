using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class Dijkstra
    {
        private int rank = 0;
        private int[,] L;
        private int[,] path;
        int[] traversal;
        private int[] C;
        public int[] D;
        private int trank = 0;
        public Dijkstra(int paramRank, int[,] paramArray)
        {
            L = new int[paramRank, paramRank];
            path = new int[paramRank, paramRank];
            traversal = new int[paramRank];
            C = new int[paramRank];
            D = new int[paramRank];
            rank = paramRank;
            for (int i = 0; i < rank; i++)
            {
                for (int j = 0; j < rank; j++)
                {
                    L[i, j] = paramArray[i, j];
                }
            }

            for (int i = 0; i < rank; i++)
            {
                C[i] = i;
            }
            C[0] = -1;
            for (int i = 1; i < rank; i++)
                D[i] = L[0, i];
        }
        public int DijkstraSolving()
        {
            int minValue = Int32.MaxValue;
            int minNode = 0;
            for (int i = 0; i < rank; i++)
            {
                if (C[i] == -1)
                    continue;
                if (D[i] > 0 && D[i] < minValue)
                {
                    minValue = D[i];
                    minNode = i;
                }
            }
            C[minNode] = -1;
            for (int i = 0; i < rank; i++)
            {
                if (L[minNode, i] < 0)
                    continue;
                if (D[i] < 0)
                {
                    D[i] = minValue + L[minNode, i];
                    continue;
                }
                if ((D[minNode] + L[minNode, i]) < D[i])
                    D[i] = minValue + L[minNode, i];
            }
            Console.WriteLine(minNode + "\n\n");
            return minNode; 
        }
        public void Run()
        {
            int minNode;
            for (trank = 0; trank < (rank); trank++)
            {
                minNode = DijkstraSolving();
                traversal[trank] = (minNode + 1);
                Console.WriteLine("iteration" + trank);
                for (int i = 0; i < rank; i++)
                    Console.Write(D[i] + " ");
                Console.WriteLine("");
                for (int i = 0; i < rank; i++)
                    Console.Write(C[i] + " ");
                Console.WriteLine("");
            }

            traversal[0] = 1;
            for(trank = 1; trank < rank; trank++)
            {
                Console.Write(traversal[trank]);
                Console.Write("  ");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //    int[,] L = new int[8,8]{
            //        {-1,  5, -1, -1, -1,  3, -1, -1},
            //        { 5, -1,  2, -1, -1, -1,  3, -1},
            //        {-1,  2, -1,  6, -1, -1, -1, 10},
            //        {-1, -1,  6, -1,  3, -1, -1, -1},
            //        {-1, -1, -1,  3, -1,  8, -1,  5},
            //        { 3, -1, -1, -1,  8, -1,  7, -1},
            //        {-1,  3, -1, -1, -1,  7, -1,  2},
            //        {-1, -1, 10, -1,  5, -1,  2, -1}
            //    };

            //    Dijkstra obj = new Dijkstra(8,L);
            //    obj.Run();

            //Random randomGenerate = new Random();
            //int size = randomGenerate.Next(5,10);
            //GraphGenerator obj = new GraphGenerator();
            //int[,] graph = obj.GraphGenerate(size);
            //for (int i = 0; i < size; i++)
            //{
            //    for(int j=0; j < size; j++)
            //    {
            //        Console.Write(graph[i, j]);
            //        Console.Write("   ");
            //    }
            //    Console.WriteLine("");
            //}
            //Console.WriteLine("\n\n\n\n");
            //Dijkstra dijkstraObj = new Dijkstra(size, graph);
            //dijkstraObj.Run();
            //Console.ReadKey();

            int[,] graph = new int[9, 9] {
                        {0, 4, 0, 0, 0, 0, 0, 8, 0}, 
                        {4, 0, 8, 0, 0, 0, 0, 11, 0}, 
                        {0, 8, 0, 7, 0, 4, 0, 0, 2}, 
                        {0, 0, 7, 0, 9, 14, 0, 0, 0}, 
                        {0, 0, 0, 9, 0, 10, 0, 0, 0}, 
                        {0, 0, 4, 0, 10, 0, 2, 0, 0}, 
                        {0, 0, 0, 14, 0, 2, 0, 1, 6}, 
                        {8, 11, 0, 0, 0, 0, 1, 0, 7}, 
                        {0, 0, 2, 0, 0, 0, 6, 7, 0} 
                    };
            DijkstraShortestPath obj = new DijkstraShortestPath(9, graph);
            obj.dijkstra(0);
            Console.ReadKey();

        }
    }
}
