using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.NthRoot.Tests
{
    [TestClass]
    public class MathTests
    {
        [TestMethod]
        public void TestNthRootPositiveNumber()
        {
            double number = 200;
            int degree = 3;
            double precision = 0.1;
            double expected = System.Math.Pow(number, 1.0 / degree);
            double actual = Task1.NthRoot.Math.NthRoot(number, degree, precision);
            double diff = System.Math.Abs(actual - expected);
            Assert.IsTrue(diff < precision);
        }

        [TestMethod]
        public void TestNthRootNegativeNumber()
        {
            double number = -200;
            int degree = 5;
            double precision = 0.0001;
            double expected = -System.Math.Pow(System.Math.Abs(number), 1.0 / degree);
            double actual = Task1.NthRoot.Math.NthRoot(number, degree, precision);
            double diff = System.Math.Abs(actual - expected);
            Assert.IsTrue(diff < precision);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNthRootArgumentValidation()
        {
            double number = -200;
            int degree = 2;
            double precision = 0.0001;
            Task1.NthRoot.Math.NthRoot(number, degree, precision);
        }
    }
}
