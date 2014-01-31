using NServiceBus;

namespace MyClient
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client, IWantCustomInitialization
    {

        public void Init()
        {
            Configure.With()
                .DefaultBuilder()
                .DefiningMessagesAs(t => t.Namespace != null && t.Namespace == "MyMessages");
        }
    }
}