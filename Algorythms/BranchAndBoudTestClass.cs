using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Algorythms
{
    [TestClass]
    public class BranchAndBoudTestClass
    {
        List<List<int>> arr;

        [TestInitialize]
        public void Initialize()
        {
            arr = new List<List<int>>()
            {
                                new List<int>() {  -1, 90, 80, 40, 100},
                new List<int>() { 60, -1, 40, 50, 70},
                new List<int>() { 50, 30, -1, 60, 20},
                new List<int>() { 10, 70, 20, -1, 50},
                new List<int>() { 20, 40, 50, 20, -1}

            };
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CalculateTest()
        {
            arr = new List<List<int>>();
            var random = new Random();

            for (int i = 0; i < 50; i++)
            {
                arr.Add(new List<int>());
                for (int j = 0; j < 50; j++)
                {
                    arr[i].Add(random.Next(10));
                }
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string s = new BranchAndBound(arr).Calculate();
            stopwatch.Stop();
            Debug.WriteLine("Результат: " + s, "Алгоритм працював " + stopwatch.ElapsedMilliseconds + " мілісекунд");

            new BranchAndBound(null).Calculate();
        }

        [TestMethod]
        public void GetDiWithZero()
        {
            arr = new List<List<int>>()
            {
                new List<int>() {  -1, 90, 80, 0, 100},
                new List<int>() { 60, -1, 40, 50, 70},
                new List<int>() { 0, 30, -1, 60, 20},
                new List<int>() { 10, 70, 20, -1, 50},
                new List<int>() { 20, 40, 50, 0, -1}

            };

            BranchAndBound bb = new BranchAndBound(arr);
            int[] res = bb.GetDi();
            int[] assert = new[] { 0, 40, 0, 10, 0 };

            for (int i = 0; i < res.Length; i++)
            {
                Assert.AreEqual(assert[i], res[i]);
            }
        }

        [TestMethod]
        public void GetDiWithoutZero()
        {
            BranchAndBound bb = new BranchAndBound(arr);
            int[] res = bb.GetDi(false);
            int[] assert = new[] { 40, 40, 20, 10, 20 };

            for (int i = 0; i < res.Length; i++)
            {
                Assert.AreEqual(assert[i], res[i]);
            }
        }

        [TestMethod]
        public void GetDjWithZero()
        {
            arr = new List<List<int>>()
            {
                new List<int>() {  -1, 90, 80, 0, 100},
                new List<int>() { 60, -1, 40, 50, 70},
                new List<int>() { 0, 30, -1, 60, 20},
                new List<int>() { 10, 70, 20, -1, 50},
                new List<int>() { 20, 40, 50, 0, -1}

            };

            BranchAndBound bb = new BranchAndBound(arr);
            int[] res = bb.GetDj();
            int[] assert = new[] { 0, 30, 20, 0, 20 };

            for (int i = 0; i < res.Length; i++)
            {
                Assert.AreEqual(assert[i], res[i]);
            }
        }

        [TestMethod]
        public void GetDjWithoutZero()
        {
            BranchAndBound bb = new BranchAndBound(arr);
            int[] res = bb.GetDj(false);
            int[] assert = new[] { 10, 30, 20, 20, 20 };

            for (int i = 0; i < res.Length; i++)
            {
                Assert.AreEqual(assert[i], res[i]);
            }
        }

        [TestMethod]
        public void CheckSourceUri()
        {
            BranchAndBound b = new BranchAndBound();
            Assert.IsTrue(Uri.IsWellFormedUriString(b.GetSourceCode(), UriKind.RelativeOrAbsolute));
        }

        [TestMethod]
        public void CheckDescriptionUri()
        {
            BranchAndBound b = new BranchAndBound();
            Assert.IsTrue(Uri.IsWellFormedUriString(b.GetDescription(), UriKind.RelativeOrAbsolute));
        }
    }
}
