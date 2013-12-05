using System;
using Messages.Commands;
using Messages.Events;
using NServiceBus;

namespace LienPublishHandler
{
    public class ProcessLienDocumentCommandHandler : IHandleMessages<ProcessLienDocumentCommand>
    {
        private readonly IBus _serviceBus;

        public ProcessLienDocumentCommandHandler(IBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public void Handle(ProcessLienDocumentCommand message)
        {
            Console.WriteLine("Publishing LienDocumentPublished event");
            _serviceBus.Publish<ILienDocumentPublishedEvent>(e =>
            {
                e.Name = message.DocumentName;
                e.Type = "ILienDocumentPublishedEvent";

            });
        }
    }
}