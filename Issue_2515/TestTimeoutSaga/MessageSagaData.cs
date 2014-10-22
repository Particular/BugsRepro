namespace SagaTimeoutTest
{
    using System;

    public class MessageSagaData
    {
        public Guid MessageId { get; set; }
        public MessageSagaStatusType MessageStatus { get; set; }

        public bool MessageSucessfullyProcessed { get; set; }
    }

    public enum MessageSagaStatusType
    {
        MessageQueuedForDelivery,
        MessageSuccessfullyQueuedForMailboxDelivery,
        MessageSuccessfullyDeliveredAndPersisted
    }
}
