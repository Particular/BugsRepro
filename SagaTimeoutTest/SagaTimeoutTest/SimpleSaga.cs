using System;
using System.Threading;
using Common.Messages;
using Common.Messages.Commands;
using NServiceBus.Saga;

namespace SagaTimeoutTest
{
    using Common;

    public class SimpleSaga : Saga<SimpleSagaData>,
        IAmStartedByMessages<StartSaga>,
        IHandleTimeouts<TimeoutWithState>
    {
        public void Handle(StartSaga message)
        {
            Console.WriteLine("Starting Saga for OrderId: {0} and requesting timeout for 30 seconds", message.OrderId);
            Data.OrderId = message.OrderId;
            RequestUtcTimeout<TimeoutWithState>(TimeSpan.FromSeconds(30), t => t.OrderId = message.OrderId);
        }

        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<StartSaga>(s => s.OrderId, m => m.OrderId);
        }

        public void Timeout(TimeoutWithState state)
        {
            Console.WriteLine("Saga timeout received for: {0}", state.OrderId);
            Interlocked.Increment(ref SagaVerifier.SagasCompleted);
            MarkAsComplete();
        }

    }
}

