namespace FastCars.CustomerRelations
{
    using System;
    using NServiceBus;
    using FastCars.Events;
    public class Bootstrapper : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }
        public void Start()
        {
            Console.WriteLine("Press any key to publish an event");
            while (Console.ReadLine() != null)
            {
                Bus.Publish<ClientBecamePreferred>(m =>
                {
                    m.ClientId = Guid.NewGuid();
                    m.PreferredUntil = DateTime.Now.AddDays(30);
                });
                Console.WriteLine("Published ClientBecamePreferred event");
            }
        }

        public void Stop()
        {
        }
    }
}
