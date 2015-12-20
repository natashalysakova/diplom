using Algorythms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Algorythms
{
    public class BranchAndBound : BaseAlgorythm
    {
        public const int M = -1;

        public BranchAndBound(List<List<int>> data) : base(data) { }

        public BranchAndBound() : base()
        {
        }

        public override string Name
        {
            get
            {
                return "Метод гілок та меж";
            }
        }

        override public string Calculate()
        {
            var answer = new List<string>();
            var lowHamiltonBound = new Dictionary<Point, int>();

            var di = GetDi();

            do
            {
                for (var i = 0; i < Data.Count; i++)
                {
                    for (var j = 0; j < Data[i].Count; j++)
                    {
                        if (Data[i][j] < 0)
                            continue;
                        Data[i][j] -= di[i];
                    }
                }

                var dj = GetDj();

                for (var i = 0; i < Data.Count; i++)
                {
                    for (var j = 0; j < Data.Count; j++)
                    {
                        if (Data[j][i] < 0)
                            continue;
                        Data[j][i] -= dj[i];
                    }
                }

                var reductionConsts = new Dictionary<Point, int>();
                var h = di.Sum() + dj.Sum();


                di = GetDi(false);
                dj = GetDj(false);
                var tmp = new List<List<int>>();
                for (var i = 0; i < Data.Count; i++)
                {
                    tmp.Add(new List<int>());
                    for (var j = 0; j < Data[i].Count; j++)
                    {
                        if (Data[i][j] == 0)
                        {
                            var summ = di[i] + dj[j];
                            tmp[i].Add(summ);
                            reductionConsts.Add(new Point(i, j), summ);
                        }
                        else
                        {
                            tmp[i].Add(Data[i][j]);
                        }
                    }
                }

                if (reductionConsts.Count == 0)
                {
                    break;
                }


                var max = reductionConsts.Max(x => x.Value);
                var normal = reductionConsts.FirstOrDefault(x => x.Value == max);

                //Нижняя граница гамильтоновых циклов этого подмножества:
                var normalValue = h + normal.Value;

                //Исключение ребра проводим путем замены элемента dij = 0 на M, после чего осуществляем очередное приведение матрицы расстояний для образовавшегося подмножества(1 *, 4 *), в результате получим редуцированную матрицу.

                Data[normal.Key.Row][normal.Key.Col] = M;
                di = GetDi();
                dj = GetDj();

                for (var i = 0; i < Data.Count; i++)
                {
                    for (var j = 0; j < Data[i].Count; j++)
                    {
                        if (i == normal.Key.Row || j == normal.Key.Col)
                            Data[i][j] = M;
                    }
                }

                var otherValue = h + di.Sum() + dj.Sum();
                //Debug.WriteLine("H = " + normalValue);
                //Debug.WriteLine("H' = " + otherValue);

                Data[normal.Key.Col][normal.Key.Row] = M;
                di = GetDi();
                dj = GetDj();


                lowHamiltonBound.Add(normal.Key, otherValue <= normalValue ? otherValue : normalValue);

                //Data.PrintMatrix(di, dj, M);
            } while (true);


            for (var i = 0; answer.Count < lowHamiltonBound.Count; i++)
            {
                var pair = lowHamiltonBound.ToList()[i];
                answer.Add((pair.Key.Row+1).ToString());

                var c = lowHamiltonBound.ToList().First(x => x.Key.Row == pair.Key.Col);
                i = lowHamiltonBound.ToList().IndexOf(c) - 1;
            }


            //Второй вариант вывода пути
            //for (int i = 0; answer.Count < lowHamiltonBound.Count; i++)
            //{
            //    var pair = lowHamiltonBound.ToList()[i];

            //    if (i == 0)
            //    {
            //        answer.Add($"{_chars[pair.Key.Row]}");
            //        answer.Add($"{_chars[pair.Key.Col]}");
            //    }
            //    else
            //    {
            //        answer.Add($"{_chars[pair.Key.Col]}");
            //    }

            //    KeyValuePair<Point, int> c = lowHamiltonBound.ToList().First(x => x.Key.Row == pair.Key.Col);
            //    i = lowHamiltonBound.ToList().IndexOf(c) - 1;
            //}

            if(answer.Count > 0)
                answer.Add(answer[0]);

            return string.Join(" -> ", answer);
        }

        internal int[] GetDi(bool withZero = true)
        {
            var di = new int[Data.Count];
            for (var i = 0; i < Data.Count; i++)
            {
                di[i] = Data[i].GetMinimum(withZero);
            }
            return di;
        }

        internal int[] GetDj(bool withZero = true)
        {
            var transpData = Data.TransData();
            var dj = new int[Data.Count];

            for (var i = 0; i < Data.Count; i++)
            {
                dj[i] = transpData[i].GetMinimum(withZero);
            }
            return dj;
        }



        public override string GetDescription()
        {
            return "/description/bandb.mht";
        }

        public override string GetSourceCode()
        {
            return "/description/bandbsource.mht";
        }

        private class Point
        {
            public Point(int row, int col)
            {
                Row = row;
                Col = col;
            }

            public int Row { get; }
            public int Col { get; }
        }
    }
}