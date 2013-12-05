namespace Messages.Events
{
    public interface ILienDocumentPublishedEvent : IDocumentPublishedEvent
    {
        string Type { get; set; }
    }
}