using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensionista.TestCases
{
    public class SampleServiceClass:IServiceInterface
    {
        public void DoSomeStuff()
        {
            throw new NotImplementedException();
        }

        public string DoSomethingWithArgs(string arg1, string arg2)
        {
            return string.Format("{0}: {1}", arg1, arg2);
        }
    }
}
