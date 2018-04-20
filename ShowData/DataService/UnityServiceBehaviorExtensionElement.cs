using CommonLib.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;
using Unity;

namespace DataService
{
    public class UnityServiceBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {

            get { return typeof(UnityServiceBehavior); }
        }

        protected override object CreateBehavior()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IDataAccessible, StaticDataDao>();
            return new UnityServiceBehavior(container);
        }
    }
}