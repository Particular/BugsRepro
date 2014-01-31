using System;
using MyMessages;
using NServiceBus;
using NServiceBus.Features;

namespace MyClient
{
    class DataResponseMessageHandler : IHandleMessages<DataResponseMessage>
    {
        public void Handle(DataResponseMessage message)
        {
            Console.WriteLine("Response received with description: {0}", message.String);
        }
    }
    
    public class PreventSubscription : IWantCustomInitialization
    {
        public void Init()
        {
            Configure.Features.Disable<AutoSubscribe>();
            //so we don't end up subscribing to DataResponseMessage
        }
    }
}
