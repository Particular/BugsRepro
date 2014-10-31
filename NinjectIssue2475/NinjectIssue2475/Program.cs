using System;
using Ninject;
using NServiceBus;

class Program
{

    static void Main()
    {
        var busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("NinjectIssue2475");
        busConfiguration.UseSerialization<JsonSerializer>();
        busConfiguration.UsePersistence<InMemoryPersistence>();
        var standardKernel = new StandardKernel();
        busConfiguration.UseContainer<NinjectBuilder>(c => c.ExistingKernel(standardKernel));
        busConfiguration.EnableInstallers();
        var startableBus = Bus.Create(busConfiguration);
        using (var bus = startableBus.Start())
        {
            bus.SendLocal(new MyMessage());
            Console.WriteLine("\r\nPress enter key to stop program\r\n");
            Console.Read();
        }
    }
}