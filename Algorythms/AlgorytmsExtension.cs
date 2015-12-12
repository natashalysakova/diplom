using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms
{
    public static class AlgorytmsExtension
    {

        public static int GetMinimum(this List<int> array, bool withZero)
        {
            var min = int.MaxValue;
            if (withZero)
            {
                foreach (var i in array)
                {
                    if (i < min && i >= 0)
                        min = i;
                }
            }
            else
            {
                var countOfZero = 0;
                foreach (var i in array)
                {
                    if (i == 0)
                        countOfZero++;
                    if (countOfZero > 1)
                        return 0;

                    if (i < min && i > 0)
                        min = i;
                }
            }

            if (min == int.MaxValue)
                return 0;

            return min;
        }

        public static List<List<int>> TransData(this List<List<int>> data)
        {
            var trans = new List<List<int>>();
            for (var i = 0; i < data.Count; i++)
            {
                trans.Add(new List<int>());
                for (var j = 0; j < data[i].Count; j++)
                {
                    trans[i].Add(data[j][i]);
                }
            }

            return trans;
        }

        public static void PrintMatrix(this List<List<int>> data, int[] di, int[] dj, int M)
        {
            Debug.WriteLine("========================");
            for (var i = 0; i <= data.Count; i++)
            {
                Debug.Write(i + "\t");
            }
            Debug.Write("\n");
            for (var i = 0; i < data.Count; i++)
            {
                Debug.Write((i + 1) + " |\t");
                for (var j = 0; j < data[i].Count; j++)
                {
                    if (data[i][j] == M)
                        Debug.Write(" \t");
                    else
                        Debug.Write(data[i][j] + "\t");
                }
                Debug.WriteLine("|" + di[i]);
            }
            Debug.Write("\t");
            for (var i = 0; i < data.Count; i++)
            {
                Debug.Write(dj[i] + "\t");
            }
            Debug.Write(di.Sum() + dj.Sum());

            Debug.Write("\n");
            Debug.WriteLine("========================");
        }

        public static void PrintMatrix(this List<List<int>> data, int M)
        {
            Debug.WriteLine("========================");
            for (int i = 0; i <= data.Count; i++)
            {
                Debug.Write(i + "\t");
            }
            Debug.Write("\n");
            for (int i = 0; i < data.Count; i++)
            {
                Debug.Write((i + 1) + " |\t");
                for (int j = 0; j < data[i].Count; j++)
                {
                    if (data[i][j] == M)
                        Debug.Write(" \t");
                    else
                        Debug.Write(data[i][j] + "\t");
                }
            }
            Debug.Write("\t");
            Debug.Write("\n");
            Debug.WriteLine("========================");

        }
    }
}
