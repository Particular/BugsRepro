using System;
using System.Threading;
using Messages;
using NServiceBus;

namespace Worker
{
    public class TestMessageHandler : IHandleMessages<TestMessage>
    {
        public void Handle(TestMessage message)
        {
            Thread.Sleep(10000);
            Console.WriteLine("Got message");
        }
    }
}