using System.Diagnostics;
using Common.Messages;
using NServiceBus;
using Publisher1.Messages;

namespace Subscriber
{
    public class EventHandler : IHandleMessages<IMyEvent>
    {
        public IBus Bus { get; set; }

        public void Handle(IMyEvent message)
        {
            Debug.Assert(message is OneEvent);
        }
    }
}