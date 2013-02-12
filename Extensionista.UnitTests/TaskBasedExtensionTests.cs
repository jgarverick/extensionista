using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.ComponentModel;
using Extensionista.TestCases;
using System.Threading.Tasks;

namespace Extensionista.UnitTests
{
    [TestFixture]
    public class TaskBasedExtensionTests
    {
        [Test]
        public void TestHitch()
        {
            string ex = "Testing!";
            string actual = string.Empty;
            EventExample obj = new EventExample();
            obj.Hitch<PropertyChangedEventHandler>("PropertyChanged", (s, e) => { Console.WriteLine(e.PropertyName); actual = ex; });
            obj.OnPropertyChanged(ex);
            Assert.AreEqual(ex, actual);
            StringBuilder sb = new StringBuilder();
            obj = new EventExample();
            List<PropertyChangedEventHandler> handlers = new List<PropertyChangedEventHandler>();
            handlers.Add((s, e) => sb.Append("Test\r\n"));
            handlers.Add((s, e) => sb.Append("This would send an email...\r\n"));
            handlers.Add((s, e) => sb.Append("The value of the property name is " + e.PropertyName + Environment.NewLine));
            obj.Hitch<PropertyChangedEventHandler>("PropertyChanged", handlers);
            obj.OnPropertyChanged(ex);
            Assert.IsTrue(sb.ToString().Length > 0);
        }

        [Test]
        public void TestRunTaskAsync()
        {
            List<int> numbers = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < 1000; i++)
            {
                numbers.Add(rnd.Next(1, 15765));
            }
            int index1 = numbers[0];
            int index500 = numbers[499];
            StringBuilder sb = new StringBuilder();
            numbers.RunTaskAsync((num) =>  sb.Append(Math.Round(num * 1.0875, 2) + Environment.NewLine));

            //Assert.IsTrue(index1 < numbers[0]);
            //Assert.IsTrue(index500 < numbers[499]);
        }

        [Test]
        public void TestRunTaskParallel()
        {
            List<int> numbers = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < 1000; i++)
            {
                numbers.Add(i);
            }

            StringBuilder sb = new StringBuilder();
            numbers.RunTaskParallel((num) => sb.Append(Math.Round(num * 1.0875, 2) + Environment.NewLine));

            Assert.IsTrue(!string.IsNullOrEmpty(sb.ToString()));
            //Assert.IsTrue(index500 < numbers[499]);
        }

        [Test]
        public void TestRunTaskBlocking()
        {
            List<int> numbers = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < 100000; i++)
            {
                numbers.Add(i);
            }
            List<double> returnValues = numbers.RunTaskBlocking((num) => num * 1.0875);

            Assert.IsTrue(returnValues.Count > 0);
            //Assert.IsTrue(index500 < numbers[499]);
        }

        [Test]
        public void TestRunTaskBlockingLimited()
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < 100000; i++)
            {
                numbers.Add(i);
            }
            List<double> returnValues = numbers.RunTaskBlocking((num) => num * 1.0875, 10);

            Assert.IsTrue(returnValues.Count > 0);
            //Assert.IsTrue(index500 < numbers[499]);
        }
    }
}
