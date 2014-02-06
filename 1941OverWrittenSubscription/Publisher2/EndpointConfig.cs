using System;

namespace Shared
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With()
                .DefiningCommandsAs(t => IsMessageNamespace(t) && t.Name.EndsWith("Command"))
                .DefiningEventsAs(t => IsMessageNamespace(t) && t.Name.EndsWith("Event"))
                .DefiningMessagesAs(t => IsMessageNamespace(t) && t.Name.EndsWith("Message"))
                .DefiningEncryptedPropertiesAs(p => p.Name.StartsWith("Encrypted"))
                .DefineEndpointName(GetType().Assembly.GetName().Name.ToLower())
                .DefaultBuilder()
                .RavenPersistence()
                .RavenSubscriptionStorage();
        }

        static bool IsMessageNamespace(Type t)
        {
            return t.Namespace != null && (t.Namespace.StartsWith("Common") || t.Namespace.Contains("Messages"));
        }
    }
}
