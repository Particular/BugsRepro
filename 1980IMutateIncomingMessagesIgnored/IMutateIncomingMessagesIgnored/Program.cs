using System;
using NServiceBus;
using NServiceBus.Installation.Environments;
using NServiceBus.Unicast;

class Program
{

    static void Main()
    {
        var bus = CreateBus();
            bus.SendLocal(new MyMessage());
        Console.WriteLine("Press any key to exit");
        Console.Read();
        bus.Dispose();
    }

    static UnicastBus CreateBus()
    {
        Configure.GetEndpointNameAction = () => "IMutateIncomingMessagesIgnored";

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

        Configure.Component<MutateIncomingMessages>(DependencyLifecycle.InstancePerCall);

        return (UnicastBus) configure.UnicastBus()
            .CreateBus().Start(() => Configure.Instance.ForInstallationOn<Windows>().Install());
    }

}