namespace SagaTimeoutTest
{
    using NServiceBus;
    using System;

    public class StartSaga : ICommand
    {
        public Guid MessageId { get; set; }
    }
    public class ProcessSomething : ICommand
    {
        public Guid MessageId { get; set; }
    }
}
