using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Extensionista;
using System.ComponentModel;

namespace Extensionista.UnitTests
{
    [TestFixture]
    public class ConversionExtensionTests
    {
        [Test]
        public void TestGetConverterKnownTypes()
        {
            String tester = "new value";
            TypeConverter converter = tester.GetConverter();
            Assert.IsTrue(converter is StringConverter);

            DateTime now = DateTime.Now;
            converter = now.GetConverter();
            Assert.IsTrue(converter is DateTimeConverter);

            Boolean b = true;
            converter = b.GetConverter();
            Assert.IsTrue(converter is BooleanConverter);

            Double d = 14.44;
            converter = d.GetConverter();
            Assert.IsTrue(converter is DoubleConverter);
            var dItem = d.ConvertValue("14.44");
            Assert.IsTrue(dItem == d);

            decimal dec = 14.44m;
            converter = dec.GetConverter();
            Assert.IsTrue(converter is DecimalConverter);
            var decItem = dec.ConvertValue("14.44");
            Assert.IsTrue(decItem == dec);

            Int16 small = 1;
            converter = small.GetConverter();
            Assert.IsTrue(converter is Int16Converter);
            var item = small.ConvertValue("4");
            Assert.IsTrue(item == 4);
            item = small.ConvertValue("1000000");
            Assert.IsTrue(item == 0);

            int medium = 1;
            converter = medium.GetConverter();
            Assert.IsTrue(converter is Int32Converter);
            var item2 = medium.ConvertValue("2141654");
            Int16 item16 = "1".ConvertValue<Int16>();
            Int64 item64 = "1".ConvertValue<Int64>();
            Assert.IsTrue(item16 == medium);
            Assert.IsTrue(item64 == medium);
            Assert.IsTrue(item2 == 2141654);

        }


    }
}
