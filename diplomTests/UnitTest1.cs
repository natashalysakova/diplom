using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorythms;
using System.Diagnostics;

namespace Algorythms
{
    [TestClass]
    public class BranchAndBoudTestClass
    {
        [TestMethod]
        public void CalculateTest()
        {
            List<List<int>> arr = new List<List<int>>()
            {
                new List<int>() {  -1, 90, 80, 40, 100},
                new List<int>() { 60, -1, 40, 50, 70},
                new List<int>() { 50, 30, -1, 60, 20},
                new List<int>() { 10, 70, 20, -1, 50},
                new List<int>() { 20, 40, 50, 20, -1}

            };

            string s = new BranchAndBound().Calculate(arr);
            Debug.WriteLine(s);
        }
    }
}
