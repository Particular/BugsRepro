using System;
using System.Runtime.InteropServices;
using NServiceBus;

public class MyHandler : IHandleMessages<MyMessage>
{
    public void Handle(MyMessage message)
    {
        //this should cause a AccessViolationException
        var ptr = new IntPtr(42);
        Marshal.StructureToPtr(42, ptr, true);
    }
}