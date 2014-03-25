using System.Collections.Generic;
using NServiceBus;

public class MyMessage : IMessage
{
    public IEnumerable<string> Foo { get; set; }
}