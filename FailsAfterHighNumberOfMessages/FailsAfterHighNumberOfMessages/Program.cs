using System;
using NServiceBus;
using NServiceBus.Installation.Environments;
using NServiceBus.Unicast;

class Program
{

    static void Main()
    {
        var bus = CreateBus();
        for (int i = 0; i < 10000; i++)
        {
            bus.SendLocal(new MyMessage());
        }
        Console.WriteLine("Press any key to exit");
        Console.Read();
        bus.Dispose();
    }

    static UnicastBus CreateBus()
    {
        Configure.GetEndpointNameAction = () => "FailsAfterHighNumberOfMessages";

        Logging.ConfigureLogging();
        var configure = Configure.With();
        configure
            .DefaultBuilder()
            .MsmqTransport()
            .JsonSerializer()
            .InMemorySagaPersister()
            .UseInMemoryTimeoutPersister()
            .Sagas()
            .InMemorySubscriptionStorage();


        return (UnicastBus) configure.UnicastBus()
            .CreateBus().Start(() => Configure.Instance.ForInstallationOn<Windows>().Install());
    }

}