﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.468
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Extensionista.TestCases.ExampleServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ExampleServiceReference.IServiceInterface")]
    public interface IServiceInterface {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceInterface/DoSomeStuff", ReplyAction="http://tempuri.org/IServiceInterface/DoSomeStuffResponse")]
        void DoSomeStuff();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceInterface/DoSomethingWithArgs", ReplyAction="http://tempuri.org/IServiceInterface/DoSomethingWithArgsResponse")]
        string DoSomethingWithArgs(string arg1, string arg2);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceInterfaceChannel : Extensionista.TestCases.ExampleServiceReference.IServiceInterface, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceInterfaceClient : System.ServiceModel.ClientBase<Extensionista.TestCases.ExampleServiceReference.IServiceInterface>, Extensionista.TestCases.ExampleServiceReference.IServiceInterface {
        
        public ServiceInterfaceClient() {
        }
        
        public ServiceInterfaceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceInterfaceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceInterfaceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceInterfaceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoSomeStuff() {
            base.Channel.DoSomeStuff();
        }
        
        public string DoSomethingWithArgs(string arg1, string arg2) {
            return base.Channel.DoSomethingWithArgs(arg1, arg2);
        }
    }
}
