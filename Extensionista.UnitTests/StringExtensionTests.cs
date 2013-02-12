using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Extensionista;

namespace Extensionista.UnitTests
{
    [TestFixture]
    public class StringExtensionTests
    {
        [Test]
        public void TestToDelimitedArray()
        {
            string[] array = new string[] { "Item 1", "ITem 2", "Item 3" };
            string concat = array.ToDelimitedString('|');
            Assert.IsTrue(concat.Contains("|"));
            Assert.IsTrue(concat.Split('|').Count() == 3);
            Assert.IsFalse(concat.EndsWith("|"));
        }

        [Test]
        public void TestToDelimitedList()
        {
            List<string> array = new List<string> { "Item 1", "ITem 2", "Item 3" };
            string concat = array.ToDelimitedString('|');
            Assert.IsTrue(concat.Contains("|"));
            Assert.IsTrue(concat.Split('|').Count() == 3);
            Assert.IsFalse(concat.EndsWith("|"));
        }

        [Test]
        public void TestBase64Methods()
        {
            string testString = "The quick brown fox jumps over the lazy d0g.";
            Assert.AreEqual(testString, (testString.EncodeBase64()).DecodeBase64());
        }
    }
}
