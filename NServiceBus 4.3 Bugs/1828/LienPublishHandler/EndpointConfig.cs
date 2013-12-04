
using NServiceBus;

namespace LienPublishHandler
{
    public class EndpointConfig : IConfigureThisEndpoint, IWantCustomInitialization, AsA_Publisher
    {
        public void Init()
        {
            Configure.With()
                     .DefineEndpointName("LienPublishHandler")
                     .UnityBuilder()
                     .UseNHibernateSubscriptionPersister()
                     .DefiningCommandsAs(type => type.Namespace != null && type.Namespace.EndsWith("Commands"))
                     .DefiningEventsAs(type => type.Namespace != null && type.Namespace.EndsWith("Events"))
                     .DisableTimeoutManager();
        }
    }
}
