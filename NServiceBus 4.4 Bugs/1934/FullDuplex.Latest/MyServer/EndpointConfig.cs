using NServiceBus;

namespace MyServer
{
    [EndpointSLA("00:00:30")]
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {

        public void Init()
        {
            Configure.With()
                .DefaultBuilder()
                .DefiningMessagesAs(t => t.Namespace != null && t.Namespace == "MyMessages");
        }
    }
}