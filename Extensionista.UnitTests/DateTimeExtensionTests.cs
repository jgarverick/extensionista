using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Extensionista;

namespace Extensionista.UnitTests
{
    [TestFixture]
    public class DateTimeExtensionTests
    {
        DateTime testq1 = DateTime.Parse("1/1/2011");
        DateTime testq2 = DateTime.Parse("4/1/2011");
        DateTime testq3 = DateTime.Parse("7/1/2011");
        DateTime testq4 = DateTime.Parse("10/1/2011");

        [Test]
        public void TestGetQuarter()
        {
            Assert.AreEqual(1, testq1.GetQuarter());
            Assert.AreEqual(2, testq2.GetQuarter());
            Assert.AreEqual(3, testq3.GetQuarter());
            Assert.AreEqual(4, testq4.GetQuarter());
        }

        [Test]
        public void TestCompareQuarter()
        {
            Assert.IsTrue(testq1.CompareQuarter(DateTime.Parse("3/15/1970")));
            Assert.IsFalse(testq1.CompareQuarter(DateTime.Parse("6/1/1994")));

            Assert.IsTrue(testq2.CompareQuarter(DateTime.Parse("5/25/1996")));
            Assert.IsFalse(testq2.CompareQuarter(DateTime.Parse("9/12/1901")));

            Assert.IsTrue(testq3.CompareQuarter(DateTime.Parse("8/15/1970")));
            Assert.IsFalse(testq3.CompareQuarter(DateTime.Parse("2/1/1994")));

            Assert.IsTrue(testq4.CompareQuarter(DateTime.Parse("11/15/1970")));
            Assert.IsFalse(testq4.CompareQuarter(DateTime.Parse("6/1/1994")));
        }

        [Test]
        public void TestClosestBusinessDay()
        {
            Assert.AreEqual(DayOfWeek.Monday, DateTime.Parse("6/26/11").ClosestBusinessDay().DayOfWeek);
            Assert.AreEqual(DayOfWeek.Friday, DateTime.Parse("6/25/11").ClosestBusinessDay().DayOfWeek);
            Assert.AreEqual(DayOfWeek.Wednesday, DateTime.Parse("6/29/11").ClosestBusinessDay().DayOfWeek);
        }
    }
}
