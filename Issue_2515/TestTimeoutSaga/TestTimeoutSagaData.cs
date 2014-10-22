namespace SagaTimeoutTest
{
    using System;
    using NServiceBus.Saga;

    public class TestTimeoutSagaData : ContainSagaData
    {
        [Unique]
        public Guid MessageId { get; set; }    
    }
}
