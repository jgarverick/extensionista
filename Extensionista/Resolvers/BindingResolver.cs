using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Extensionista
{
    internal class BindingResolver
    {
        public static Binding Resolve(WcfBindingTypes type)
        {
            Binding binding = null;
            switch (type)
            {
                case WcfBindingTypes.BasicHttpBinding:
                    binding = new BasicHttpBinding();
                    break;
                case WcfBindingTypes.NetTcpBinding:
                    binding = new NetTcpBinding();
                    break;
                case WcfBindingTypes.NetTcpContextBinding:
                    binding = new NetTcpContextBinding();
                    break;
                case WcfBindingTypes.WsHttpBinding:
                    binding = new WSHttpBinding();
                    break;
                case WcfBindingTypes.NetMsmqBinding:
                    binding = new NetMsmqBinding();
                    break;
                case WcfBindingTypes.NetPeerTcpBinding:
                    binding = new NetPeerTcpBinding();
                    break;
                case WcfBindingTypes.BasicHttpContextBinding:
                    binding = new BasicHttpContextBinding();
                    break;
                case WcfBindingTypes.WSHttpContextBinding:
                    binding = new WSHttpContextBinding();
                    break;
                case WcfBindingTypes.WS2007FederationHttpBinding:
                    binding = new WS2007FederationHttpBinding();
                    break;
                case WcfBindingTypes.WS2007HttpBinding:
                    binding = new WS2007HttpBinding();
                    break;
                case WcfBindingTypes.NetNamedPipeBinding:
                    binding = new NetNamedPipeBinding();
                    break;
                case WcfBindingTypes.WSFederationHttpBinding:
                    binding = new WSFederationHttpBinding();
                    break;
                case WcfBindingTypes.WSDualHttpBinding:
                    binding = new WSDualHttpBinding();
                    break;
                default:
                    binding = new CustomBinding();
                    break;
            }
            return binding;
        }
    }
}
