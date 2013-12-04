using NServiceBus;

namespace Client
{
    public class EndpointConfig : IConfigureThisEndpoint, IWantCustomInitialization, AsA_Client
    {
        public void Init()
        {
            Configure.With()
                     .DefineEndpointName("Client")
                     .DefiningCommandsAs(type => type.Namespace != null && type.Namespace.EndsWith("Commands"))
                     .DefiningEventsAs(type => type.Namespace != null && type.Namespace.EndsWith("Events"))
                     .DisableTimeoutManager()
                     .UnityBuilder();
        }
    }
}