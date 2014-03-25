using System.Diagnostics;
using System.Linq;
using NServiceBus;

public class MyHandler : IHandleMessages<MyMessage>
{
    public void Handle(MyMessage message)
    {
        Debug.WriteLine(message.Foo.First());
    }
}