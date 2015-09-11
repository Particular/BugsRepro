using System;
using Messages;
using NServiceBus;

namespace Subscriber2
{
    class SomethingHappenedHandler : IHandleMessages<SomethingHappened>
    {
        public void Handle(SomethingHappened message)
        {
            Console.WriteLine("Subscriber2 has received the SomethingHappened event");
        }
    }
}
