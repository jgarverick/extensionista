using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensionista.TestCases;
using Extensionista;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServiceExtTester
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleServiceClass service = new SampleServiceClass();
            using (ServiceHost host = service.GetServiceHost(WcfBindingTypes.WsHttpBinding, "https://localhost/Tests/Service.svc", ""))
            {
                host.Open();
                Console.WriteLine("Hosting service on {0}...", host.Description.Endpoints[0].Address.Uri);
                //Extensionista.TestCases.ExampleServiceReference.ServiceInterfaceClient client = new Extensionista.TestCases.ExampleServiceReference.ServiceInterfaceClient();
                //Console.WriteLine("Doing something: {0}", client.DoSomethingWithArgs("one", "2"));
                Console.Read();
            }

        }
    }
}
