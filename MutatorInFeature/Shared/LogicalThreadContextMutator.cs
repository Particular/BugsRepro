using System;
using System.Threading.Tasks;
using NServiceBus.MessageMutator;

public class LogicalThreadContextMutator: IMutateOutgoingMessages
{
    public Task MutateOutgoing(MutateOutgoingMessageContext context)
    {
        Console.WriteLine("LogicalThreadContextMutator");
        return Task.CompletedTask;
    }
}