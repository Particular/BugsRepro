using System.Diagnostics;
using NServiceBus;
using Publisher.Messages;

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