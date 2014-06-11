using System;
using System.Threading;
using Common;
using NServiceBus;
using NServiceBus.Installation.Environments;
using NServiceBus.Unicast;

class Program
{
    static void Main(string[] args)
    {
        var synchronizationContext = SynchronizationContext.Current;
        SynchronizationContext.SetSynchronizationContext(synchronizationContext);
        Configure.GetEndpointNameAction = () => "Version4";

        Configure.Serialization.Json();
        Configure.Serialization.DontWrapSingleMessages();

        Logging.ConfigureLogging();
        var configure = Configure.With();
        configure.ApplyMessageConventions();
        configure.DefaultBuilder();
        configure.UseTransport<Msmq>();
        configure.InMemorySagaPersister();
        configure.UseInMemoryTimeoutPersister();

        var bus = (UnicastBus)configure.UnicastBus()
            .CreateBus().Start(() => configure.ForInstallationOn<Windows>().Install());

        bus.Send("Version3", new SimpleMessage());
        Console.ReadLine();
    }
}