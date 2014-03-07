using System.Diagnostics;
using CommonMessages;
using NServiceBus;

public static class SendReturnInitiator
{

    public static void InitiateSendReturn(this IBus bus)
    {
            bus.SendLocal(new SendReturnMessage())
                .Register<int>(i =>
                {
                    Debug.WriteLine(bus.CurrentMessageContext.ReplyToAddress.Queue);
                });
    }
}