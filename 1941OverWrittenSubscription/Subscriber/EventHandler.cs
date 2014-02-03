using Common.Messages;
using NServiceBus;

namespace Subscriber
{
    public class EventHandler : IHandleMessages<IMyEvent>
    {
        public IBus Bus { get; set; }

        public void Handle(IMyEvent message)
        {
            Verifier.EventReceivedFrom.Add(Bus.CurrentMessageContext.ReplyToAddress.Queue);
        }
    }
}