namespace SagaTimeoutTest
{
    using System;
    using NServiceBus.Saga;

    public class SimpleSagaData : IContainSagaData
    {
        public Guid Id { get; set; }
        public string OriginalMessageId { get; set; }
        public string Originator { get; set; }

        [Unique]
        public string OrderId { get; set; }
    }
}
