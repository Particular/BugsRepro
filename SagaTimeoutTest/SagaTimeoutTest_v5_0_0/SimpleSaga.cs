
namespace SagaTimeoutTest
{
    using System;
    using System.Threading;
    using Common;
    using Common.Messages;
    using Common.Messages.Commands;
    using NServiceBus.Saga;

    public class SimpleSaga : Saga<SimpleSagaData>,
           IAmStartedByMessages<StartSaga>,
           IHandleTimeouts<TimeoutWithState>
    {
        public void Handle(StartSaga message)
        {
            Console.WriteLine("Starting Saga for OrderId: {0} and requesting timeout for 30 seconds", message.OrderId);
            Data.OrderId = message.OrderId;
            RequestTimeout<TimeoutWithState>(TimeSpan.FromSeconds(30), t => t.OrderId = message.OrderId);
        }

        public void Timeout(TimeoutWithState state)
        {
            Console.WriteLine("Saga timeout received for: {0}", state.OrderId);
            Interlocked.Increment(ref SagaVerifier.SagasCompleted);
            MarkAsComplete();
        }


        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<SimpleSagaData> mapper)
        {
            mapper.ConfigureMapping<StartSaga>(m => m.OrderId).ToSaga(s => s.OrderId);
        }
    }
}
