using System.Collections.Generic;
using NServiceBus;
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

public class MyMessage : IMessage
{
    public IEnumerable<string> Foo { get; set; }
}