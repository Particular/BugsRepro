using System.Diagnostics;
using Common;
using NServiceBus;

public class Handler : IHandleMessages<SimpleMessage>
{
    public void Handle(SimpleMessage simpleMessage)
    {
        Debug.WriteLine("Foo");
    }
}