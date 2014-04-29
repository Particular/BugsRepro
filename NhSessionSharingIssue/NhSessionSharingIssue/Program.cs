using System;
using System.Diagnostics;
using NHibernate.Tool.hbm2ddl;
using NhSessionSharingIssue.NServiceBusSerilog;
using NServiceBus;
using NServiceBus.Installation.Environments;
using Serilog;
using Serilog.Events;

class Program
{

    static void Main()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.ColoredConsole(LogEventLevel.Information)
            .WriteTo.RollingFile("log-{Date}.txt", LogEventLevel.Information)
            .CreateLogger();

        SerilogConfigurator.Configure();

        Configure.GetEndpointNameAction = () => "NhSessionSharingIssue";

        Configure.Serialization.Json();

        NHibernateSessionBuilder.GetFluentConfiguration()
         .ExposeConfiguration(
              c => new SchemaExport(c).Execute(false, true, false))
         .BuildConfiguration();

        var bus = Configure.With()
            .CastleWindsorBuilder()
            .UseTransport<SqlServer>()
            .UseNHibernateSagaPersister()
            .UseInMemoryTimeoutPersister()
            .InMemorySubscriptionStorage()
            .UnicastBus()
            .CreateBus();
        bus.Start(Startup);
        bus.SendLocal(new MyMessage());
        Console.WriteLine("\r\nPress any key to stop program\r\n");
        Console.Read();
        bus.Shutdown();
    }

    static void Startup()
    {
        //Only create queues when a user is debugging
        if (Environment.UserInteractive && Debugger.IsAttached)
        {
            Configure.Instance.ForInstallationOn<Windows>().Install();
        }
    }

}