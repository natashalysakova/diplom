using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

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
            string s = new BranchAndBound().Calculate(arr);
            Assert.AreNotEqual(0, s.Length);

            new BranchAndBound().Calculate(null);
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

            int[] res = BranchAndBound.GetDi(arr);
            int[] assert = new[] { 0, 40, 0, 10, 0 };

            for (int i = 0; i < res.Length; i++)
            {
                Assert.AreEqual(assert[i], res[i]);
            }
        }

        [TestMethod]
        public void GetDiWithoutZero()
        {
            int[] res = BranchAndBound.GetDi(arr, false);
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

            int[] res = BranchAndBound.GetDj(arr);
            int[] assert = new[] { 0, 30, 20, 0, 20 };

            for (int i = 0; i < res.Length; i++)
            {
                Assert.AreEqual(assert[i], res[i]);
            }
        }

        [TestMethod]
        public void GetDjWithoutZero()
        {
            int[] res = BranchAndBound.GetDj(arr, false);
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
