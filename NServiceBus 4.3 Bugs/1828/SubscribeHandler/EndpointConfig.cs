using NServiceBus;

namespace SubscribeHandler
{
    public class EndpointConfig : IConfigureThisEndpoint, IWantCustomInitialization, AsA_Server
    {
        public void Init()
        {
            Configure.With()
                .DefineEndpointName("SubscribeHandler")
                .UnityBuilder()
            //    .UseNHibernateTimeoutPersister()
             //   .UseNHibernateSagaPersister()
                .DefiningCommandsAs(type => type.Namespace != null && type.Namespace.EndsWith("Commands"))
                .DefiningEventsAs(type => type.Namespace != null && type.Namespace.EndsWith("Events"));

        }
    }
}