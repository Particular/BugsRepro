using System;
using Messages;
using NServiceBus;

namespace Sender
{
    public class Sender : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Press <enter> to send a message");
                Console.ReadLine();
                Bus.Send(new TestMessage());
            }
        }

        public void Stop()
        {
        }
    }
}