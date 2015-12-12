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

        public override string Name
        {
            get
            {
                return "Метод гілок та меж";
            }
        }

        override public string Calculate(List<List<int>> data)
        {
            base.Calculate(data);

            var answer = new List<string>();
            var lowHamiltonBound = new Dictionary<Point, int>();

            var di = GetDi(data);

            do
            {
                for (var i = 0; i < data.Count; i++)
                {
                    for (var j = 0; j < data[i].Count; j++)
                    {
                        if (data[i][j] < 0)
                            continue;
                        data[i][j] -= di[i];
                    }
                }

                var dj = GetDj(data);

                for (var i = 0; i < data.Count; i++)
                {
                    for (var j = 0; j < data.Count; j++)
                    {
                        if (data[j][i] < 0)
                            continue;
                        data[j][i] -= dj[i];
                    }
                }

                var reductionConsts = new Dictionary<Point, int>();
                var h = di.Sum() + dj.Sum();


                di = GetDi(data, false);
                dj = GetDj(data, false);
                var tmp = new List<List<int>>();
                for (var i = 0; i < data.Count; i++)
                {
                    tmp.Add(new List<int>());
                    for (var j = 0; j < data[i].Count; j++)
                    {
                        if (data[i][j] == 0)
                        {
                            var summ = di[i] + dj[j];
                            tmp[i].Add(summ);
                            reductionConsts.Add(new Point(i, j), summ);
                        }
                        else
                        {
                            tmp[i].Add(data[i][j]);
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

                data[normal.Key.Row][normal.Key.Col] = M;
                di = GetDi(data);
                dj = GetDj(data);

                for (var i = 0; i < data.Count; i++)
                {
                    for (var j = 0; j < data[i].Count; j++)
                    {
                        if (i == normal.Key.Row || j == normal.Key.Col)
                            data[i][j] = M;
                    }
                }

                var otherValue = h + di.Sum() + dj.Sum();
                Debug.WriteLine("H = " + normalValue);
                Debug.WriteLine("H' = " + otherValue);

                data[normal.Key.Col][normal.Key.Row] = M;
                di = GetDi(data);
                dj = GetDj(data);


                lowHamiltonBound.Add(normal.Key, otherValue <= normalValue ? otherValue : normalValue);

                data.PrintMatrix(di, dj, M);
            } while (true);


            for (var i = 0; answer.Count < lowHamiltonBound.Count; i++)
            {
                var pair = lowHamiltonBound.ToList()[i];
                answer.Add($"({pair.Key.Row}, {pair.Key.Col})");

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

            answer.Add(answer[0]);

            return string.Join(" => ", answer);
        }

        internal static int[] GetDi(List<List<int>> data, bool withZero = true)
        {
            var di = new int[data.Count];
            for (var i = 0; i < data.Count; i++)
            {
                di[i] = data[i].GetMinimum(withZero);
            }
            return di;
        }

        internal static int[] GetDj(List<List<int>> data, bool withZero = true)
        {
            var transpData = data.TransData();
            var dj = new int[data.Count];

            for (var i = 0; i < data.Count; i++)
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