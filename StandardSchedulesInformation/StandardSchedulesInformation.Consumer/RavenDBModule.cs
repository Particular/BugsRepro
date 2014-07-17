using Ninject;
using Ninject.Modules;
using NServiceBus.ObjectBuilder.Ninject;
using Raven.Client;
using Raven.Client.Document;

namespace StandardSchedulesInformation.Consumer
{
    public class RavenDBModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDocumentStore>().To<DocumentStore>()
                .InSingletonScope()
                .OnActivation(store =>
                {
                    store.Conventions.FailoverBehavior = FailoverBehavior.AllowReadsFromSecondariesAndWritesToSecondaries;
                    store.ConnectionStringName = "RavenDB";
                    store.Initialize();
                });

            Bind<IDocumentSession>().ToMethod(ctx => ctx.Kernel.Get<IDocumentStore>().OpenSession()).InUnitOfWorkScope();
        }
    }
}