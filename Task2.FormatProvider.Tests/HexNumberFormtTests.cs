using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.FormatProvider.Tests
{
    [TestClass]
    public class HexNumberFormtTests 
    {
        [TestMethod]
        public void TestPositiveNumbers()
        {
            int decValue = 2730;
            string expected = String.Format("{0:X8}", decValue);
            string actual = String.Format(new HexNumberFormat(), "{0:HEX}", decValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNegativeNumbers()
        {
            int decValue = -2730;
            string expected = String.Format("{0:X8}", decValue);
            string actual = String.Format(new HexNumberFormat(), "{0:HEX}", decValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateTypeArgument()
        {
            string decValue = "-2730";
            //string expected = decValue;
            string expected = String.Format("{0:X8}", decValue);
            string actual = String.Format(new HexNumberFormat(), "{0:HEX}", decValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateFormatName()
        {
            int decValue = 2730;
            string expected = String.Format("{0:HE}", decValue);
            string actual = String.Format(new HexNumberFormat(), "{0:HE}", decValue);
            Assert.AreEqual(expected, actual);
        }
    }
}
