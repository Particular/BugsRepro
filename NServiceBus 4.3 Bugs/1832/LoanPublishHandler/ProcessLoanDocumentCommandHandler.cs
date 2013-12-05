using System;
using Messages;
using Messages.Commands;
using Messages.Events;
using NServiceBus;

namespace LoanPublishHandler
{
    public class ProcessLoanDocumentCommandHandler : IHandleMessages<ProcessLoanDocumentCommand>
    {
        private readonly IBus _serviceBus;

        public ProcessLoanDocumentCommandHandler(IBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public void Handle(ProcessLoanDocumentCommand message)
        {

            Console.WriteLine("Publishing LoanDocumentPublished event");
         
            _serviceBus.Publish<ILoanDocumentPublishedEvent>(e =>
                {
                    e.Name = message.DocumentName;
                });
        }
    }
}
