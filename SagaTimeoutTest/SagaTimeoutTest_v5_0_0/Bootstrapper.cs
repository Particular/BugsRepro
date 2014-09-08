namespace SagaTimeoutTest_v5_0_0
{
    using System;
    using System.Threading;
    using Common;
    using NServiceBus;

    class Bootstrapper : IWantToRunWhenBusStartsAndStops
    {
        public void Start()
        {
            Thread.Sleep(15 * 1000);

            if (SagaVerifier.SagasCompleted != SagaVerifier.TotalTimeoutsToRequest)
                throw new Exception("Timeouts did not complete");

            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        public void Stop()
        {

        }
    }
}
