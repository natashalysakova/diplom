using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Algorythms
{
    [TestClass]
    public class DynamicalProgrammingTestClass
    {
        List<List<int>> arr;
        DynamicalProgramming dp;

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

            dp = new DynamicalProgramming(arr);
        }

        [TestMethod]
        public void SimpleBellmanCorrectTest()
        {
            int res = dp.Bellman(1, 2);

            Assert.AreEqual(11, res);
        }

        [TestMethod]
        public void ComplicateBellmanCorrectTest()
        {
            int res = dp.BellmanRec(1, new List<int> { 2, 3 });

            Assert.AreEqual(7, res);
        }

        [TestMethod]
        public void SoComplecatedBellmanCorrectTest()
        {
            int res = dp.BellmanRec(0, new List<int> { 1, 2, 3 });

            Assert.AreEqual(8, res);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullExceptionTest()
        {
            DynamicalProgramming p = new DynamicalProgramming(null);
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
            dp.Data = arr;
            string s = dp.Calculate();
            stopwatch.Stop();
            Debug.WriteLine("Результат: " + s, "Алгоритм працював " + stopwatch.ElapsedMilliseconds + " мілісекунд");
        }

        [TestMethod]
        public void CheckSourceUri()
        {
            DynamicalProgramming b = new DynamicalProgramming();
            Assert.IsTrue(Uri.IsWellFormedUriString(b.GetSourceCode(), UriKind.RelativeOrAbsolute));
        }

        [TestMethod]
        public void CheckDescriptionUri()
        {
            DynamicalProgramming b = new DynamicalProgramming();
            Assert.IsTrue(Uri.IsWellFormedUriString(b.GetDescription(), UriKind.RelativeOrAbsolute));
        }
    }
}