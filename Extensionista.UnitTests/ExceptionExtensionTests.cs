using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Extensionista;

namespace Extensionista.UnitTests
{
    [TestFixture]
    public class ExceptionExtensionTests
    {
        [Test()]
        public void TestUnwindMessageOnly()
        {
            Exception Toplevel = new Exception("This is a top level exception.");
            Exception Nested1 = new Exception("This is nested at the first inner exception.");
            var contents = Toplevel.Unwind();
            Assert.IsTrue(contents.Split('\r', '\n').Where(x=> !string.IsNullOrEmpty(x)).ToList().Count() == 1);
            Toplevel = new Exception("This is a top level exception.", Nested1);
            contents = Toplevel.Unwind();
            Assert.IsTrue(contents.Split('\r', '\n').Where(x => !string.IsNullOrEmpty(x)).ToList().Count() == 2);
            contents = Toplevel.Unwind(true);
            Assert.IsTrue(contents.Split('\r', '\n').Where(x => !string.IsNullOrEmpty(x)).ToList().Count() > 0);
        }
    }
}
