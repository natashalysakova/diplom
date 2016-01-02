using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Algorythms
{
    public class CombineMethod : BaseAlgorythm
    {

        private const int M = -1;

        public override string Name
        {
            get
            {
                return "Комбінований алгоритм";
            }
        }

        public CombineMethod(List<List<int>> data) : base(data)
        {

        }

        public CombineMethod() : base()
        {
        }

        public override string Calculate()
        {
            StringBuilder sb = new StringBuilder();
            Graph g = new Graph(Data);
            try
            {
                List<Tuple<int, int>> theShortest = g.findShortest();

                foreach (Tuple<int, int> i in theShortest)
                    sb.Append("( " + i.Item1 + " " + i.Item2 + " )");
                return sb.ToString();
            }
            catch (Exception)
            {
                BranchAndBound bb = new BranchAndBound(Data);
                return bb.Calculate();
            }


            
        }


        public override string GetDescription()
        {
            return "/description/combine.mht";
        }

        public override string GetSourceCode()
        {
            return "/description/combinesource.mht";
        }


        private class Graph
        {
            int[,] matrix;
            bool[,] used;

            public Graph(List<List<int>> data)
            {
                int[,] tmp = new int[data.Count, data[0].Count];
                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < data[i].Count; j++)
                    {
                        tmp[i, j] = data[i][j];
                    }
                }

                this.matrix = tmp;
                this.used = new bool[matrix.GetLength(0), matrix.GetLength(1)];
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        if (i == j) used[i, j] = true;
            }


            public List<Tuple<int, int, int>> byPass()
            {
                int n = matrix.GetLength(0);
                for (int i = 0; i < n; i++)
                {
                    int minI = Int32.MaxValue;
                    for (int j = 0; j < n; j++)
                        if (!used[i, j])
                            if (matrix[i, j] < minI) minI = matrix[i, j];

                    for (int j = 0; j < n; j++)
                        if (!used[i, j])
                            matrix[i, j] -= minI;
                }

                for (int i = 0; i < n; i++)
                {
                    int minJ = Int32.MaxValue;
                    for (int j = 0; j < n; j++)
                        if (!used[i, j])
                            if (matrix[j, i] < minJ) minJ = matrix[j, i];
                    for (int j = 0; j < n; j++)
                        if (!used[i, j])
                            matrix[j, i] -= minJ;
                }

                List<Tuple<int, int, int>> allZero = new List<Tuple<int, int, int>>();
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (!used[i, j])
                            if (matrix[i, j] == 0)
                            {
                                int minIValue = Int32.MaxValue;
                                int minI = Int32.MaxValue;
                                int minJValue = Int32.MaxValue;
                                int minJ = Int32.MaxValue;

                                for (int a = 0; a < n; a++)
                                {
                                    if (!used[a, j])
                                        if (matrix[a, j] < minIValue && a != i) minIValue = matrix[a, j];
                                    minI = a;
                                }

                                for (int a = 0; a < n; a++)
                                {
                                    if (!used[i, a])
                                        if (matrix[i, a] < minJValue && a != j) minJValue = matrix[i, a];
                                    minJ = a;
                                }

                                allZero.Add(new Tuple<int, int, int>(minIValue + minJValue, i, j));
                            }

                allZero.Sort((a, b) => a.Item1.CompareTo(b.Item1));

                for (int i = 0; i < allZero.Count; i++)
                    if (allZero[i] != allZero[0]) allZero.RemoveAt(i);

                return allZero;

            }

            public List<Tuple<int, int>> findShortest()
            {
                List<Tuple<int, int>> shortestWay = new List<Tuple<int, int>>();

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    List<Tuple<int, int, int>> allZero = this.byPass();
                    int delI = allZero[0].Item2;
                    int delJ = allZero[0].Item3;
                    shortestWay.Add(new Tuple<int, int>(delI, delJ));
                    for (int a = 0; a < matrix.GetLength(0); a++)
                    {
                        used[delI, a] = true;
                        used[a, delJ] = true;
                    }
                }
                return shortestWay;
            }
        }
    }
}
