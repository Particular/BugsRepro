using System;
using Messages.Events;
using NServiceBus;

namespace SagaEndpoint
{
    public class BaseEventMessageHandler : IHandleMessages<IBaseEvent>
    {
        public void Handle(IBaseEvent message)
        {
            Console.WriteLine("Subscribe: Processed event of type '{0}'", message.GetType().FullName);
        }
    }
}