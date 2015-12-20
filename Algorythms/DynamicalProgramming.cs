using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Algorythms
{
    public class DynamicalProgramming : BaseAlgorythm
    {

        private const int M = -1;
        string result = string.Empty;

        public override string Name
        {
            get
            {
                return "Метод динамічного програмування";
            }
        }

        public DynamicalProgramming(List<List<int>> data) : base(data)
        {

        }

        public DynamicalProgramming() : base()
        {
        }

        public override string Calculate()
        {

            List<int> param = Enumerable.Range(1, Data.Count - 1).ToList();
            int weight = BellmanRec(0, param);
            return result;
        }

        public override string GetDescription()
        {
            return "/description/dynamical.mht";
        }

        public override string GetSourceCode()
        {
            return "/description/dynamicalsource.mht";
        }

        internal int Bellman(int i, int j)
        {
            if (i == j)
                throw new ArgumentException("i must be not equal j");

            if (j < 0 || j >= Data.Count)
                throw new ArgumentOutOfRangeException("j must be between 0 and " + (Data.Count - 1));

            if (i < 0 || i >= Data.Count)
                throw new ArgumentOutOfRangeException("i must be between 0 and " + (Data.Count - 1));
            return Data[i][j] + Data[j][0];
        }

        internal int BellmanRec(int i, List<int> js, bool firstlevel = true)
        {

            if (js.Count == 1)
                return Bellman(i, js[0]);

            foreach (var j in js)
            {
                if (j < 0 || j >= Data.Count)
                    throw new ArgumentOutOfRangeException("j must be between 0 and " + (Data.Count - 1));
            }

            if (i < 0 || i >= Data.Count)
                throw new ArgumentOutOfRangeException("i must be between 0 and " + (Data.Count - 1));

            List<int> tmp = new List<int>();
            foreach (var j in js)
            {
                List<int> param = new List<int>();
                for (int k = 0; k < js.Count; k++)
                {
                    if (js[k] != j)
                        param.Add(js[k]);
                }
                tmp.Add(Data[i][j] + BellmanRec(j, param, false));
            }

            int globalMin = tmp.Min();

            if (firstlevel)
            {
                List<int> path = new List<int>();

                int min = int.MaxValue;
                path.Add(i + 1);
                tmp.Insert(0, int.MaxValue);
                do
                {
                    min = tmp.Min();
                    if (min == int.MaxValue)
                        break;
                    int ind = tmp.IndexOf(min);
                    path.Add(ind + 1);
                    tmp[ind] = int.MaxValue;
                } while (true);
                path.Add(i + 1);

                result = string.Join(" -> ", path);
            }

            return globalMin;
        }


    }
}
