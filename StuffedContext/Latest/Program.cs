using System;
using System.Reflection;
using System.Threading;
using NServiceBus;
using NServiceBus.Installation.Environments;
using NServiceBus.Unicast;

class Program
{

    static void Main()
    {

        var bus = CreateBus();

        Thread.Sleep(TimeSpan.FromSeconds(10));
        SynchronizationContext.SetSynchronizationContext(null);
        bus.InitiateSendReturn();

        Thread.Sleep(TimeSpan.FromSeconds(10));
        bus.Dispose();
    }

    static UnicastBus CreateBus()
    {
        Configure.GetEndpointNameAction = () => "WireCompat" + Assembly.GetExecutingAssembly().GetName().Name;

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