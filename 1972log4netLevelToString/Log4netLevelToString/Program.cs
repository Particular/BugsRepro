using System;
using log4net.Config;
using NServiceBus;
using NServiceBus.Installation.Environments;
using NServiceBus.Unicast;

class Program
{

    static void Main()
    {
        var bus = CreateBus();
        Console.WriteLine("Press any key to exit");
        Console.Read();
        bus.Dispose();
    }

    static UnicastBus CreateBus()
    {
        Configure.GetEndpointNameAction = () => "Log4netLevelToString";

        XmlConfigurator.Configure();
        var configure = Configure.With()
            .Log4Net()
            .DefaultBuilder()
            .RavenSubscriptionStorage()
            .UseRavenTimeoutPersister();
        configure
            .UnicastBus();

        return (UnicastBus) configure.UnicastBus()
            .CreateBus().Start(() => Configure.Instance.ForInstallationOn<Windows>().Install());
    }

}