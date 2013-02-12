using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensionista.TestCases
{
    [Serializable]
    public class SampleClass : ISampleInterface
    {
        public void DoWork()
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
