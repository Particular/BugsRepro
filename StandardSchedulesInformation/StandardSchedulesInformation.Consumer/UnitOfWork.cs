using System;
using NServiceBus.UnitOfWork;
using Raven.Client;

namespace StandardSchedulesInformation.Consumer
{
    public class UnitOfWork : IManageUnitsOfWork
    {
        private readonly IDocumentSession session;

        public UnitOfWork(IDocumentSession session)
        {
            this.session = session;
        }

        public void Begin()
        {
            // Can be left empty with RavenDB
        }

        public void End(Exception ex = null)
        {
            if (ex != null)
            {
                return;
            }

            session.SaveChanges();
        }
    }

}