using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;
using Unity;

namespace DataService
{
    public class UnityServiceBehavior : IServiceBehavior
    {
        IUnityContainer _container;
        
        public UnityServiceBehavior(IUnityContainer container)
        {
            _container = container;

        }
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {

        }



        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var cdb in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher cd = cdb as ChannelDispatcher;

                if (cd != null)
                {
                    foreach (var ed in cd.Endpoints)
                    {
                        Type serviceType = serviceDescription.ServiceType;
                        IInstanceProvider provider = new UnityInstanceProvider(_container, serviceType);
                        ed.DispatchRuntime.InstanceProvider = provider;
                    }
                }
            }
        }
        
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

    }
}