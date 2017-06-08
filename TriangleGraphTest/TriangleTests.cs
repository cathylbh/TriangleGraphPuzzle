using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleLib;
using System.Collections.Generic;

namespace TriangleGraphTest
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void LabelsForLargeGraphs()
        {
            TriangleCalculation calc = new TriangleCalculation(12, 56, 10, 10);
            var results = calc.GetTriangleCoordinates();

            string key = "";

            foreach (string item in results.Keys)
            {
                key = item;
            }

            Assert.AreEqual("BD12", key);

        }
    }
}
