using NServiceBus;

namespace StandardSchedulesInformation.Consumer
{
    public class Watcher : IWantToRunWhenBusStartsAndStops
    {

        public IBus Bus { get; set; }

        public void Start()
        {
        }

        public void Stop()
        {
        }
    }
}