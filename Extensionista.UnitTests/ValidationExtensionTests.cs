using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Extensionista.TestCases;
using System.ComponentModel.DataAnnotations;

namespace Extensionista.UnitTests
{
    [TestFixture]
    public class ValidationExtensionTests
    {
        [Test]
        public void TestObjectFail()
        {
            SampleValidationClass obj = new SampleValidationClass();
            bool tryit = obj.TryValidate();
            Assert.IsFalse(tryit);
            List<ValidationResult> results = obj.Validate();
            Assert.IsTrue(results.Count > 0);
        }

        [Test]
        public void TestObjectPass()
        {
            SampleValidationClass val = new SampleValidationClass();
            val.RecordID = 1;
            val.RecordName = "TestRecord";
            bool tryit = val.TryValidate();
            Assert.IsTrue(tryit);

        }
    }
}
