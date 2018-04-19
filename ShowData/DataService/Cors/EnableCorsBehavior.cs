using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace DataService.Cors
{
    public class EnableCorsBehavior : BehaviorExtensionElement, IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) { }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new EnableCorsMessageInspector());
        }
        public void Validate(ServiceEndpoint endpoint) { }
        public override Type BehaviorType
        {
            get { return typeof(EnableCorsBehavior); }
        }
        protected override object CreateBehavior()
        {
            return new EnableCorsBehavior();
        }
    }
}