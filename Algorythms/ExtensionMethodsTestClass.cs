using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms
{
    [TestClass]
    public class ExtensionMethodsTestClass
    {
        [TestMethod]
        public void GetMinimumWithoutZeroTest()
        {
            List<int> list = new List<int>() { 10, 20, 0, 50, 70, 45, 6, 15 };

            Assert.AreEqual(6, list.GetMinimum(false));
        }

        [TestMethod]
        public void GetMinimumWithZeroTest()
        {
            List<int> list = new List<int>() { 10, 20, 0, 50, 70, 45, 6, 15 };

            Assert.AreEqual(0, list.GetMinimum(true));
        }


        [TestMethod]
        public void TransDataTest()
        {
            List<List<int>> list = new List<List<int>>()
            {
                new List<int>() { 10, 20 },
                new List<int>() {30,40 }
            };

            List<List<int>> result = list.TransData();

            Assert.AreEqual(10, result[0][0]);
            Assert.AreEqual(30, result[0][1]);
            Assert.AreEqual(20, result[1][0]);
            Assert.AreEqual(40, result[1][1]);


        }
    }
}
