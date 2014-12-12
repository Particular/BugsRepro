using System;
using NServiceBus;
using NServiceBus.Installation.Environments;

class Program
{
    static void Main()
    {
        Configure.GetEndpointNameAction = () => "MaxTimeIncrease";
        Logging.ConfigureLogging();

        Configure.Serialization.Json();
        var bus = Configure.With()
            .DefaultBuilder()
            .InMemorySagaPersister()
            .UseInMemoryTimeoutPersister()
            .InMemorySubscriptionStorage()
            .PurgeOnStartup(true)
            .UnicastBus()
            .CreateBus();
        bus.Start(Startup);
        bus.SendLocal(new MyMessage());
        Console.WriteLine("\r\nPress any key to stop program\r\n");
        Console.Read();
    }


    static void Startup()
    {
        Configure.Instance.ForInstallationOn<Windows>().Install();
    }

}