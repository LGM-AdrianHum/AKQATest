// File: TestApi/TestUnitTests/ApiTest.cs
// User: Adrian Hum/
// 
// Created:  2018-02-13 8:41 AM
// Modified: 2018-02-13 8:53 AM

using NUnit.Framework;
using TestApi.Helpers;
using TestApi.Models;

namespace TestUnitTests
{
    [TestFixture]
    public class ApiTest
    {
        [Test]
        public void TestController()
        {
            var m = new ChequeDetails("Adrian Hum", 123.45M);
            var u = m.DollarWords;
            Assert.AreEqual(u, "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS");
        }

        [Test]
        public void TestNumberToWordsDecimal()
        {
            Assert.AreEqual(CurrencyHelper.NumberToWords(1.00M), "ONE DOLLAR AND ZERO CENTS");
            Assert.AreEqual(CurrencyHelper.NumberToWords(41.38M), "FORTY-ONE DOLLARS AND THIRTY-EIGHT CENTS");
            Assert.AreEqual(CurrencyHelper.NumberToWords(141.38M),
                "ONE HUNDRED AND FORTY-ONE DOLLARS AND THIRTY-EIGHT CENTS");
        }

        [Test]
        public void TestNumberToWordsInt()
        {
            Assert.AreEqual(CurrencyHelper.NumberToWords(1), "one");
            Assert.AreEqual(CurrencyHelper.NumberToWords(2), "two");
            Assert.AreEqual(CurrencyHelper.NumberToWords(21), "twenty-one");
            Assert.AreEqual(CurrencyHelper.NumberToWords(1000000), "one million ");
            Assert.AreEqual(CurrencyHelper.NumberToWords(1000), "one thousand ");
            Assert.AreEqual(CurrencyHelper.NumberToWords(-1001), "minus one thousand and one");
            Assert.AreEqual(CurrencyHelper.NumberToWords(-1101), "minus one thousand one hundred and one");
        }
    }
}