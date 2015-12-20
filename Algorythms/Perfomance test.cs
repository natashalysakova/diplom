using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms
{
    [TestClass]
    public class Perfomance_test
    {
        int Count = 6;
        List<List<int>> arr = new List<List<int>>();

        [TestMethod]
        public void PerfomanceTest()
        {
            Dictionary<IAlgorythm, Dictionary<int, List<long>>> res = new Dictionary<IAlgorythm, Dictionary<int, List<long>>>();
            List<IAlgorythm> instances = new List<IAlgorythm>() { new DynamicalProgramming(), new BranchAndBound(), new CombineMethod() };
            //List<IAlgorythm> instances = new List<IAlgorythm> { new BranchAndBound() };

            Count = 1000;
            NewData();
            Recalculate(res, instances);

            Count = 10000;
            NewData();
            Recalculate(res, instances);

            foreach (var alg in  res)
            {
                Debug.WriteLine(alg.Key.Name);
                foreach (var item in alg.Value)
                {
                    var values = item.Value.Where(x => x != 0);
                    if(values.Count() != 0)
                        Debug.WriteLine($"Count: {item.Key} - Avg Time: {values.Average()}");
                    else
                        Debug.WriteLine($"Count: {item.Key} - Avg Time: undefined");

                }
            }
        }

        private void Recalculate(Dictionary<IAlgorythm, Dictionary<int, List<long>>> res, List<IAlgorythm> instances)
        {
            foreach (var item in instances)
            {
                if (item.GetType() == typeof(DynamicalProgramming) && Count > 12)
                    continue;

                if (!res.ContainsKey(item))
                {
                    res.Add(item, new Dictionary<int, List<long>>());
                }

                for (int i = 0; i < 2; i++)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    item.Data = arr;
                    stopwatch.Start();
                    item.Calculate();
                    stopwatch.Stop();
                    if (!res[item].ContainsKey(Count))
                    {
                        res[item].Add(Count, new List<long>());
                    }
                    res[item][Count].Add(stopwatch.ElapsedMilliseconds);
                }

            }
        }

        private void NewData()
        {

            arr = new List<List<int>>();
            var random = new Random();

            for (int i = 0; i < Count; i++)
            {
                arr.Add(new List<int>());
                for (int j = 0; j < Count; j++)
                {
                    if (i == j)
                        arr[i].Add(-1);
                    else
                        arr[i].Add(random.Next(10));
                }
            }
        }
    }
}
