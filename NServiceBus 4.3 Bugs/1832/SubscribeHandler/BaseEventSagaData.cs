using NServiceBus.Saga;

namespace SagaEndpoint
{
    public class BaseEventSagaData : ContainSagaData
    {
        [Unique]
        public virtual string Name { get; set; }

    }
}