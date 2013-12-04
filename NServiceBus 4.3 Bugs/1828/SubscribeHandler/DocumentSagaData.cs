using NServiceBus.Saga;

namespace SubscribeHandler
{
    public class DocumentSagaData : ContainSagaData
    {
        [Unique]
        public virtual string Name { get; set; }

        public virtual bool IsLoanDocComplete { get; set; }
        public virtual bool IsLienDocComplete { get; set; }
    }
}