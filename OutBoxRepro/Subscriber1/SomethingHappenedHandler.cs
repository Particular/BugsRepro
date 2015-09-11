using System;
using Messages;
using NServiceBus;

namespace Subscriber1
{
    class SomethingHappenedHandler : IHandleMessages<SomethingHappened>
    {
        public void Handle(SomethingHappened message)
        {
            Console.WriteLine("Subscriber1 has received the SomethingHappened event");
        }
    }
}
