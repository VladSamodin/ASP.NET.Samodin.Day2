using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.GCD;

namespace Task3.GCD.Tests
{
    [TestClass]
    public class AlgorithmsTests
    {
        #region GCD Euclidean algorithm tests
        [TestMethod]
        public void GCDEuclidean2PositiveParamsTest()
        {
            const int a = 30;
            const int b = 18;
            const int expected = 6;
            TimeSpan runTime;
            int actual = Algorithms.GCDEuclidean(out runTime, a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GCDEuclidean2NegativeParamsTest()
        {
            const int a = -30;
            const int b = -18;
            const int expected = 6;
            TimeSpan runTime;
            int actual = Algorithms.GCDEuclidean(out runTime, a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GCDEuclidean3ParamsTest()
        {
            const int a = 11310;
            const int b = 5382;
            const int c = 14586;
            const int expected = 78;
            TimeSpan runTime;
            int actual = Algorithms.GCDEuclidean(out runTime, a, b, c);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GCDEuclidean4ParamsTest()
        {
            //int[] array = new int[] { 38688, 11310, 5382, 14586 };
            const int a = 38688;
            const int b = 5382;
            const int c = 14586;
            const int d = 11310;
            const int expected = 78;
            TimeSpan runTime;
            int actual = Algorithms.GCDEuclidean(out runTime, a, b, c, d);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region GCD Binary algorithm tests
        [TestMethod]
        public void GCDBinary2PositiveParamsTest()
        {
            const int a = 30;
            const int b = 18;
            const int expected = 6;
            TimeSpan runTime;
            int actual = Algorithms.GCDBinary(out runTime, a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GCDBinary2NegativeParamsTest()
        {
            const int a = -30;
            const int b = -18;
            const int expected = 6;
            TimeSpan runTime;
            int actual = Algorithms.GCDBinary(out runTime, a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GCDBinary3ParamsTest()
        {
            const int a = 11310;
            const int b = 5382;
            const int c = 14586;
            const int expected = 78;
            TimeSpan runTime;
            int actual = Algorithms.GCDBinary(out runTime, a, b, c);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GCDBinary4ParamsTest()
        {
            //int[] array = new int[] { 38688, 11310, 5382, 14586 };
            const int a = 38688;
            const int b = 5382;
            const int c = 14586;
            const int d = 11310;
            const int expected = 78;
            TimeSpan runTime;
            int actual = Algorithms.GCDBinary(out runTime, a, b, c, d);
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}
