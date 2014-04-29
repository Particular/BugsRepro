using NServiceBus;
using NServiceBus.Saga;
using Serilog;

namespace NhSessionSharingIssue
{



    public class MySaga : Saga<MySagaData>, IHandleMessages<MyMessage>
    {
        static ILogger logger = Log.ForContext<MyHandler>();

        public void Handle(MyMessage message)
        {
            logger.Information("Hello From MySaga");
            int id;
            using (var sessionFactory = NHibernateSessionBuilder.BuildFactory())
            {
                using (var session = sessionFactory.OpenSession())
                {
                    var product = new Product { Name = "Foo" };
                    session.Save(product);
                    id = product.Id;
                }
                using (var session = sessionFactory.OpenSession())
                {
                    var product = session.Load<Product>(id);
                    logger.Information("Loaded " + product.Name);
                }
                logger.Information("Successfully Savedb and retrieved from DB");
            }
        }
    }

    public class MySagaData : ContainSagaData
    {
    }

}

