using System.Configuration;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

static class NHibernateSessionBuilder
{
    public static ISessionFactory BuildFactory()
    {
        return  GetFluentConfiguration()
            .BuildSessionFactory();
    }

    public static FluentConfiguration GetFluentConfiguration()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["NServiceBus/Persistence"].ConnectionString;
        return Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
            .Mappings(m =>
                m.AutoMappings
                    .Add(AutoMap.AssemblyOf<Product>().Where(t => t == typeof (Product))));
    }
}