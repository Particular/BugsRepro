using System;
using Messages.Events;
using NServiceBus;

namespace SagaEndpoint
{
    class Bootstrapper : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            int index = 1;
            Console.WriteLine("Press Enter to publish derived events");
            while (Console.ReadLine() != null)
            {
                Bus.Publish<IDerivedType1Event>(m => { m.Name = string.Format("Index:{0}", index++); });
                Bus.Publish<IDerivedType2Event>(m => { m.Name = string.Format("Index:{0}", index++); });
            }
        }

        public void Stop()
        {
            
        }
    }
}
