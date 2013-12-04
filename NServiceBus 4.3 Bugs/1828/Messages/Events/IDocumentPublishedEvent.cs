using System;

namespace Messages.Events
{
    public interface IDocumentPublishedEvent
    {
        string Name { get; set; }
    }
}
