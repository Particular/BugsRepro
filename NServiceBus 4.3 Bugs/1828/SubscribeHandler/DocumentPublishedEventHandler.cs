using System;
using Messages;
using Messages.Events;
using NServiceBus;

namespace SubscribeHandler
{
    public class DocumentPublishedEventHandler : IHandleMessages<IDocumentPublishedEvent>
    {
        public void Handle(IDocumentPublishedEvent message)
        {
            Console.WriteLine("Subscribe: Processed event of type '{0}'", message.GetType().FullName);
        }
    }
}