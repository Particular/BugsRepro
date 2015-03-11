using System;
using System.ServiceModel;
using Messages;
using NServiceBus;
using WcfService;

namespace Worker
{
    public class TestMessageHandler : IHandleMessages<TestMessage>
    {
        public void Handle(TestMessage message)
        {
            var channelFactory = new ChannelFactory<ISlowService>(new BasicHttpBinding(), "http://localhost:6666/Greeter");
            var proxy = channelFactory.CreateChannel();
            var greetings = proxy.Greet("Indu");
            
            Console.WriteLine(greetings);
        }
    }
}