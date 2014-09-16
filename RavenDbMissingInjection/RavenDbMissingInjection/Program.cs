using System;
using System.Diagnostics;
using System.ServiceProcess;
using NServiceBus;
using NServiceBus.Installation.Environments;
using NServiceBus.RavenDB;

class Program
{

    static void Main()
    {
        Configure.GetEndpointNameAction = () => "RavenDbMissingInjection";

        Configure.Serialization.Json();

        using (var bus = Configure.With()
            .DefaultBuilder()
            .RavenDBStorage()
            //comment any of the below to get the error
            .UseRavenDBSagaStorage()
            .UseRavenDBSubscriptionStorage()
            .UseRavenDBTimeoutStorage()
            .UseRavenDBGatewayDeduplicationStorage()
            .UseRavenDBGatewayStorage()
            .UnicastBus()
            .CreateBus())
        {
            bus.Start(Startup);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
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