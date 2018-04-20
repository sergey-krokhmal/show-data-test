using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;
using Unity;

namespace DataService
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        IUnityContainer _container;
        Type _serviceType;

        public UnityInstanceProvider(IUnityContainer container, Type serviceType)
        {
            _serviceType = serviceType;
            _container = container;
        }
        
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return GetInstance(instanceContext);
        }



        public object GetInstance(InstanceContext instanceContext)
        {
            return _container.Resolve(_serviceType);
        }



        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }

    }
}