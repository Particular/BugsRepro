using System;
using System.Threading;
using NServiceBus;

public class Handler : IHandleMessages<MyMessage>
{
    static int count;
    public void Handle(MyMessage myMessage)
    {
        Interlocked.Increment(ref count);
        Console.WriteLine(count);
    }
}