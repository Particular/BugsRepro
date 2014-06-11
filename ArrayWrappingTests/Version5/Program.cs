using System;
using Common;
using NServiceBus;
using UnicastBus = NServiceBus.Unicast.UnicastBus;

class Program
{

    static void Main()
    {
        var configure = Configure.With(b => b.EndpointName("Version5"));
        configure.ApplyMessageConventions();
        configure.Serialization.Json();
        configure.DefaultBuilder();

        configure.EnableInstallers();
        var startableBus = configure.CreateBus();
        var bus = (UnicastBus) startableBus.Start();

        bus.Send("Version4", new SimpleMessage());
        //bus.Send("Version4", new SendReturnMessage())
        //    .Register<int>(i =>
        //    {
        //        Debug.WriteLine("return");
        //    }
        //    );
        Console.ReadLine();
    }
}