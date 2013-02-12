using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Configuration;

namespace Extensionista
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceOrientedExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bindingType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        //public static ServiceHost GetServiceHost(this object obj, WcfBindingTypes bindingType, string baseAddress,string endpointAddress)
        //{
        //    Binding binding = BindingResolver.Resolve(bindingType);
        //    ServiceHost host = null;
        //    ServiceBehaviorAttribute attr = null;
        //    if (!(binding == null))
        //    {
        //        if (obj.GetType().GetInterfaces().ToList().Where(i => i.AttributedWith<ServiceContractAttribute>()).Any())
        //        {
        //            var contract = obj.GetType().GetInterfaces().ToList().Where(i => i.AttributedWith<ServiceContractAttribute>()).First();
                    
        //            if (contract.AttributedWith<ServiceBehaviorAttribute>())
        //                attr = (ServiceBehaviorAttribute)contract.GetCustomAttributes(true).Where(x => x is ServiceBehaviorAttribute).First();

        //            if (obj.GetType().AttributedWith<ServiceBehaviorAttribute>())
        //                attr = (ServiceBehaviorAttribute)obj.GetType().GetCustomAttributes(true).Where(x => x is ServiceBehaviorAttribute).First();

        //            host = new ServiceHost(obj.GetType(),new Uri(baseAddress));

        //            if (attr != null)
        //                if (attr.InstanceContextMode == InstanceContextMode.Single)
        //                    host = new ServiceHost(obj,new Uri(baseAddress));
                    
        //            host.AddServiceEndpoint(contract.FullName, binding, baseAddress + "/" + endpointAddress);
        //        }
                
        //        if (bindingType == WcfBindingTypes.NetTcpBinding || bindingType == WcfBindingTypes.NetPeerTcpBinding
        //            || bindingType == WcfBindingTypes.NetMsmqBinding ||
        //            bindingType == WcfBindingTypes.NetNamedPipeBinding ||
        //            bindingType == WcfBindingTypes.NetTcpContextBinding) { }
        //        else
        //        {
        //            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
        //            if (bindingType == WcfBindingTypes.WsHttpBinding &&
        //                (binding as WSHttpBinding).Scheme == "https")
        //            {
        //                smb.HttpsGetEnabled = true;
        //                smb.HttpGetEnabled = false;
        //            }else
        //            smb.HttpGetEnabled = true;
        //            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
        //            host.Description.Behaviors.Add(smb);
        //        }
                
        //        return host;
        //    }
        //    throw new InvalidOperationException("Cannot create a ServiceHost with this class.");
        //}


    }
}
