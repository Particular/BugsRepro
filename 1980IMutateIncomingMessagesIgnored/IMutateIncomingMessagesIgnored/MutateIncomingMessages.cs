using NServiceBus.MessageMutator;

public class MutateIncomingMessages : IMutateIncomingMessages
{
    public object MutateIncoming(object message)
    {
        var myMessage = (MyMessage) message;
        myMessage.Property = "Hello";
        return myMessage;
    }
}