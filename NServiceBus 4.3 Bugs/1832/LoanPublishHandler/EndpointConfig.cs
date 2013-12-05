using NServiceBus;

namespace LoanPublishHandler
{
    public class EndpointConfig : IConfigureThisEndpoint, IWantCustomInitialization, AsA_Publisher
    {
        public void Init()
        {
            Configure.With()
                     .DefineEndpointName("LoanPublishHandler")
                     .DefaultBuilder()
                     .DefiningCommandsAs(type => type.Namespace != null && type.Namespace.EndsWith("Commands"))
                     .DefiningEventsAs(type => type.Namespace != null && type.Namespace.EndsWith("Events"))
                     .DisableTimeoutManager();
        }
    }
}