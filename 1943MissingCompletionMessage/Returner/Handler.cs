using NServiceBus;

namespace Common.SendReturn
{
    public class Handler : IHandleMessages<Message>
    {
        public IBus Bus { get; set; }

        public void Handle(Message message)
        {
            Bus.Return(5);
        }
    }
}