using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;

class ConfigErrorQueue : IProvideConfiguration<MessageForwardingInCaseOfFaultConfig>
{
    public MessageForwardingInCaseOfFaultConfig GetConfiguration()
    {
        return new MessageForwardingInCaseOfFaultConfig
        {
            ErrorQueue = "error"
        };
    }
}
class ConfigTransportConfig : IProvideConfiguration<TransportConfig>
{
    public TransportConfig GetConfiguration()
    {
        return new TransportConfig
        {
            MaxRetries = 0
        };
    }
}