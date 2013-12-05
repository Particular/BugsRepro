namespace Messages.Events
{
    public interface ILoanDocumentPublishedEvent : IDocumentPublishedEvent
    {
        string Type { get; set; }
    }
}