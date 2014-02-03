using System;
using System.Diagnostics;
using System.Threading;
using NServiceBus;

namespace Common.SendReturn
{
    public class Initiator : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }


        public void Start()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Bus.Send("Returner", new Message())
                .Register<int>(i => Debug.WriteLine(i));
        }

        public void Stop()
        {
        }
    }
}