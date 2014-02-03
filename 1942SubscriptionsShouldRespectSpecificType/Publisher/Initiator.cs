using NServiceBus;
using Publisher.Messages;

namespace Publisher
{
    public class Initiator : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Bus.Publish(new OneEvent());
            Bus.Publish(new TwoEvent());
        }

        public void Stop()
        {
        }
    }
 
}