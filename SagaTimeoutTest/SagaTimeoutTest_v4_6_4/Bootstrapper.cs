
namespace SagaTimeoutTest
{
    using System;
    using System.Diagnostics;
    using Common;
    using Common.Messages.Commands;
    using NServiceBus;

    class Bootstrapper 
    {
        public IBus Bus { get; set; } 
        public void Start()
        {
            Console.WriteLine("Starting 10 sagas each of which requests a timeout for 30 seconds.");
            for (var i = 0; i < SagaVerifier.TotalTimeoutsToRequest; i++)
                Bus.SendLocal(new StartSaga() { OrderId = string.Format("Order{0}", i + 1) });
            Console.WriteLine("Wait for 28 seconds before killing endpoint");
            System.Threading.Thread.Sleep(28 * 1000);
            Console.WriteLine("Timeouts requested. Going to stop the 4.x endpoint. Now  Start the 5.x endpoint ");
            Process.GetCurrentProcess().Kill();
        }

        public void Stop()
        {

        }
    }
}
