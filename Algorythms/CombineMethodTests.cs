using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Algorythms
{
    [TestClass]
    public class CombineMethodTests
    {
        List<List<int>> arr;
        CombineMethod cm;

        [TestInitialize]
        public void Initialize()
        {
            arr = new List<List<int>>()
            {
                new List<int>() { 0, 4, 3, 4},
                new List<int>() { 2, 0, 5, 2},
                new List<int>() { 6, 2, 0, 1},
                new List<int>() { 1, 5, 4, 0},
            };

            cm = new CombineMethod();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullExceptionTest()
        {
            CombineMethod c = new CombineMethod(null);
        }

        [TestMethod]
        public void FullCalculateTest()
        {
            arr = new List<List<int>>();
            var random = new Random();

            for (int i = 0; i < 12; i++)
            {
                arr.Add(new List<int>());
                for (int j = 0; j < 12; j++)
                {
                    arr[i].Add(random.Next(10));
                }
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            cm.Data = arr;
            string s = cm.Calculate();
            stopwatch.Stop();
            Debug.WriteLine("Результат: " + s, "Алгоритм працював " + stopwatch.ElapsedMilliseconds + " мілісекунд");
        }

        [TestMethod]
        public void CheckSourceUri()
        {
            CombineMethod b = new CombineMethod();
            Assert.IsTrue(Uri.IsWellFormedUriString(b.GetSourceCode(), UriKind.RelativeOrAbsolute));
        }

        [TestMethod]
        public void CheckDescriptionUri()
        {
            CombineMethod b = new CombineMethod();
            Assert.IsTrue(Uri.IsWellFormedUriString(b.GetDescription(), UriKind.RelativeOrAbsolute));
        }

    }
}
