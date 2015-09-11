
using NServiceBus;

namespace Subscriber1
{
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.UseTransport<RabbitMQTransport>();
            configuration.Transactions().DisableDistributedTransactions();
            configuration.EnableOutbox();
            
        }
    }
}
