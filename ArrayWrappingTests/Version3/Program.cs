using System;
using System.Threading;
using NServiceBus;
using NServiceBus.Installation.Environments;
using NServiceBus.Unicast;

class Program
{
    static void Main()
    {

        var synchronizationContext = SynchronizationContext.Current;
        SynchronizationContext.SetSynchronizationContext(synchronizationContext);
        Configure.GetEndpointNameAction = () => "Version3";

        Logging.ConfigureLogging();
        var configure = Configure.With();
        configure.ApplyMessageConventions();
        configure.DefaultBuilder();
        configure.MsmqTransport();
        configure.JsonSerializer();
        configure.InMemorySagaPersister();
        configure.UseInMemoryTimeoutPersister();
        configure.RunTimeoutManager();
        configure.Sagas();

        var unicastBus = (UnicastBus) configure.UnicastBus()
            .CreateBus().Start(() => configure.ForInstallationOn<Windows>().Install());
        Console.ReadLine();
    }
}