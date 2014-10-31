using System;
using System.Diagnostics;
using Ninject.Planning;
using NServiceBus;

public class MyHandler : IHandleMessages<MyMessage>
{
    IPlanner planner;

    public MyHandler(IPlanner planner)
    {
        this.planner = planner;
    }

    public void Handle(MyMessage message)
    {
        Console.WriteLine("Hello from MyHandler");
        Debug.WriteLine(planner);
    }
}