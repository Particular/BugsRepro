using System;
using Messages.Events;
using NServiceBus.Saga;

namespace SagaEndpoint
{
    public class BaseEventSaga : Saga<BaseEventSagaData>, IAmStartedByMessages<IBaseEvent>
    {

        public void Handle(IBaseEvent message)
        {
            Console.WriteLine("Loan Doument received -- {0}", message.Name);
            Data.Name = message.Name;
            MarkAsComplete();
        }

        public override void ConfigureHowToFindSaga()
        {
            base.ConfigureHowToFindSaga();
            ConfigureMapping<IBaseEvent>(m => m.Name).ToSaga(s => s.Name);
        }
    }
}
