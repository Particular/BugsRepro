namespace SagaTimeoutTest
{
    using System;
    using NServiceBus;
    using NServiceBus.Saga;


    public class TestTimeoutSaga : Saga<TestTimeoutSagaData>,
        IAmStartedByMessages<StartSaga>,
        IHandleMessages<ProcessSomething>,
        IHandleTimeouts<ActionForSagaNotCompleteTimeout>,
        IHandleSagaNotFound

    {
        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<ProcessSomething>(message => message.MessageId).ToSaga(data => data.MessageId);
        }

        public void Handle(StartSaga message)
        {
            Console.WriteLine("Received message StartSaga");
            Data.MessageId = message.MessageId;
            RequestTimeout(DateTime.UtcNow.AddSeconds(4), new ActionForSagaNotCompleteTimeout());
            Bus.SendLocal(new ProcessSomething()
            {
                MessageId = message.MessageId
            });
            Console.WriteLine("StartSaga was successfuly processed.");
        }

        public void Handle(ProcessSomething message)
        {
            Console.WriteLine("Received ProcessSomething command");
            System.Threading.Thread.Sleep(6000);
            Console.WriteLine("*** !!! SAGA COMPLETE !!! ***");
            MarkAsComplete();
            Console.WriteLine("The ProcessSomething command was successfuly processed.  ");
        }

        public void Timeout(ActionForSagaNotCompleteTimeout state)
        {
            Console.WriteLine("*** timeout received -- going to mark the saga as COMPLETE!! !!! ***");
            MarkAsComplete();
        }

        public void Handle(object message)
        {
            Console.WriteLine("Invoked SagaNotFound -- type: {0}", message.GetType());
        }
    }
}




