using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace DataService.Cors
{
    public class EnableCorsMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var allowedOrigins = new[] { "http://localhost" };
            var httpProp = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
            if (httpProp != null)
            {
                string origin = httpProp.Headers["Origin"];
                if (origin != null && allowedOrigins.Any(x => x == origin))
                {
                    return origin;
                }
            }
            return null;
        }
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            string origin = correlationState as string;
            if (origin != null)
            {
                HttpResponseMessageProperty httpProp = null;
                if (reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))
                {
                    httpProp = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];
                }
                else
                {
                    httpProp = new HttpResponseMessageProperty();
                    reply.Properties.Add(HttpResponseMessageProperty.Name, httpProp);
                }
                httpProp.Headers.Add("Access-Control-Allow-Origin", origin);
                httpProp.Headers.Add("Access-Control-Allow-Credentials", "true");
                httpProp.Headers.Add("Access-Control-Request-Method", "POST,GET,OPTIONS");
                httpProp.Headers.Add("Access-Control-Allow-Headers", "X-Requested-With,Content-Type");
            }
        }
    }
}