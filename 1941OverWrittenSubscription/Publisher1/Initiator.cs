using NServiceBus;
using Publisher1.Messages;

namespace Publisher1
{
    public class Initiator : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Bus.Publish(new MyEvent());
        }

        public void Stop()
        {
        }
    }
 
}