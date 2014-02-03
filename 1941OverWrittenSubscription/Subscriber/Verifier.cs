using System;
using System.Collections.Generic;
using System.Threading;
using NServiceBus;

namespace Subscriber
{
    public class Verifier : IWantToRunWhenBusStartsAndStops
    {

        Timer timer;
        public IBus Bus { get; set; }

        void AssertExpectations()
        {
            foreach (var endpintName in Publishers.All)
            {
                Assert(EventReceivedFrom.Contains(endpintName), Configure.EndpointName + " expected a event to be Received From " + endpintName);
            }
            Environment.Exit(0);
        }


        public static void Assert(bool value, string message)
        {
            if (!value)
            {
                throw new Exception(message);
            }
        }
        public static List<string> EventReceivedFrom = new List<string>();

        public void Start()
        {
            timer = new Timer(state => AssertExpectations(), null, TimeSpan.FromSeconds(15), TimeSpan.FromDays(10));
        }

        public void Stop()
        {
        }
    }
}