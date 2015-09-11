
using System;
using Messages;

namespace Publisher1
{
    using NServiceBus;

    class Bootstrapper : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }
        public void Start()
        {
            while (Console.ReadLine() != null)
            {
                Bus.Publish(new SomethingHappened());
            }
        }

        public void Stop()
        {
            
        }
    }
}
