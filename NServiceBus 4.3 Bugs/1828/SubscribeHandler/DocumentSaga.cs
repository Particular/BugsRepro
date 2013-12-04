﻿using System;
using Messages.Events;
using NServiceBus.Saga;

namespace SubscribeHandler
{
    public class DocumentSaga : Saga<DocumentSagaData>, IAmStartedByMessages<ILoanDocumentPublishedEvent>,
        IAmStartedByMessages<ILienDocumentPublishedEvent>
    {
        public void Handle(ILoanDocumentPublishedEvent message)
        {
            Console.WriteLine("Loan Doument received -- {0}", message.Name);
            Data.Name = message.Name;
            Data.IsLoanDocComplete = true;
            CompleteSaga();
        }

        private void CompleteSaga()
        {
            if (Data.IsLienDocComplete && Data.IsLienDocComplete)
            {
                Console.WriteLine("Saga is now complete");
                MarkAsComplete();
            }
        }

        public void Handle(ILienDocumentPublishedEvent message)
        {
            Console.WriteLine("Lien Doument received -- {0}", message.Name);
           
            Data.Name = message.Name;
            Data.IsLienDocComplete = true;
            CompleteSaga();
        }

        public override void ConfigureHowToFindSaga()
        {
            base.ConfigureHowToFindSaga();
            ConfigureMapping<ILoanDocumentPublishedEvent>(m => m.Name)
               .ToSaga(s => s.Name);
            ConfigureMapping<ILienDocumentPublishedEvent>(m => m.Name)
                .ToSaga(s => s.Name);
        }
    }
}
