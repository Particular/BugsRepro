using System;
using System.Threading;
using NServiceBus;
using NServiceBus.Features;
using NServiceBus.Installation.Environments;

class Program
{

    static void Main()
    {
        Logging.ConfigureLogging();
        Configure.Features.Enable<Sagas>();
        Configure.Serialization.Json();
        var configure = Configure.With();
        configure.DefaultBuilder();
        configure.RavenPersistence();
        configure.UseTransport<Msmq>();

        var bus = configure.UnicastBus()
            .CreateBus().Start(() => Configure.Instance.ForInstallationOn<Windows>().Install());
        bus.SendLocal(new SagaInitiateMessage());


        var timer = new Timer(ClearSagas);
        Console.ReadLine();
    }

    static void ClearSagas(object state)
    {
        
    }
}