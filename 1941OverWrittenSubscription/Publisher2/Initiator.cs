using NServiceBus;
using Publisher2.Messages;

namespace Publisher2
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