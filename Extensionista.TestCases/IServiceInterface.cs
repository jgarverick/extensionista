using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Extensionista.TestCases
{
    [ServiceContract]
    public interface IServiceInterface
    {
        [OperationContract]
        void DoSomeStuff();
        [OperationContract]
        string DoSomethingWithArgs(string arg1, string arg2);
    }
}
