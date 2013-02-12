using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit;
using NUnit.Framework;
using System.Reflection;
using Extensionista.TestCases;
using System.Collections;
using Extensionista;

namespace Extensionista.UnitTests
{
    [TestFixture]
    public class ReflectorExtensionTests
    {
        Assembly asm;

        [TestFixtureSetUp()]
        public void Initialize()
        {
            asm = Assembly.LoadFrom("Extensionista.TestCases.dll");
        }

        [Test()]
        public void TestImplementsTypePass()
        {
            Type t = typeof(SampleClass);
            Assert.IsTrue(t.Implements<ISampleInterface>());
        }

        [Test()]
        public void TestImplementsTypeFail()
        {
            Type t = typeof(SampleClass);
            Assert.IsFalse(t.Implements<SampleDecoratedClass>());
        }

        [Test()]
        public void TestImplementsAssemblyPass()
        {
            Type[] types = asm.Implements<ISampleInterface>();
            Assert.IsNotNull(types);
            Assert.IsTrue(types.Length == 1);
        }

        [Test()]
        public void TestImplementsAssemblyFail()
        {
            Type[] types = asm.Implements<ICollection>();
            Assert.IsEmpty(types);
        }

        [Test()]
        public void TestAttributedWithAssemblyPass()
        {
            Type[] types = asm.AttributedWith<CustomTypeAttribute>();
            Assert.IsNotEmpty(types);
            Assert.IsNotNull(types);
            Assert.IsTrue(types.Length == 1);
        }

        [Test()]
        public void TestAttributedWithAssemblyFail()
        {
            Type[] types = asm.AttributedWith<DescriptionAttribute>();
            Assert.IsEmpty(types);
        }

        [Test()]
        public void TestAttributedWithTypePass()
        {
            Assert.IsTrue(typeof(SampleDecoratedClass).AttributedWith<CustomTypeAttribute>());
            Assert.IsTrue(typeof(SampleClass).AttributedWith<SerializableAttribute>());

            var item = typeof(SampleClass).ExtractAttribute<SerializableAttribute>();
            Assert.IsNotNull(item);

            var items = typeof(SampleClass).ExtractAttributes<SerializableAttribute>();
            Assert.IsTrue(items.Count > 0);
        }

        [Test()]
        [ExpectedException()]
        public void TestAttributedWithTypeFail()
        {
            Assert.IsFalse(typeof(SampleClass).AttributedWith<CustomTypeAttribute>());
            Assert.IsFalse(typeof(SampleClass).AttributedWith<SampleDecoratedClass>());

            var items = typeof(SampleClass).ExtractAttributes<string>();
        }
    }
}
