using System;
using NServiceBus;

public class Handler : IHandleMessages<MyMessage>
{
    public void Handle(MyMessage myMessage)
    {
        Console.WriteLine(myMessage.Property);
    }
}