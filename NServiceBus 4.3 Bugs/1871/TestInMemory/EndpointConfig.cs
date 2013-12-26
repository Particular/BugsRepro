
using System;

namespace TestInMemory
{
    using NServiceBus;
    using NServiceBus.Features;
	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.ScaleOut(_ => _.UseUniqueBrokerQueuePerMachine());
            Configure.Serialization.Json();
            Configure.Features
                .Disable<TimeoutManager>()
                .Disable<SecondLevelRetries>()
                .Disable<Sagas>()
                .Disable<Gateway>();

            Configure.With()
                //.DefaultBuilder()
                .CastleWindsorBuilder()
                .InMemorySubscriptionStorage()
                .InMemoryFaultManagement()
                .UnicastBus();

            //Configure.Instance.Configurer.ConfigureComponent<Handler>(DependencyLifecycle.InstancePerCall);
        }
    }

    public class Message : IEvent { }

    public class Handler : IHandleMessages<Message>
    {
        public void Handle(Message message)
        {
            Console.WriteLine("In memory handler called");
        }
    }

    public class Go : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Bus.InMemory.Raise(new Message());
        }

        public void Stop()
        {
        }
    }


}
