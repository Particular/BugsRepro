using System;
using System.Diagnostics;
using NServiceBus.Saga;

public class MySaga : Saga<MySagaData>,
    IAmStartedByMessages<SagaInitiateMessage>,
   IAmStartedByMessages<MyTimeout>,
    IHandleTimeouts<MyTimeout>
{
    public void Handle(SagaInitiateMessage message)
    {
        Data.MyProp = 100;
        RequestTimeout<MyTimeout>(TimeSpan.FromSeconds(25));
        //after this delete the saga data from raven but dont delete the timeout
    }

    public void Timeout(MyTimeout state)
    {
        // the timeout will fire but the saga data will be empty
        Debug.WriteLine(Data.MyProp);
    }

    public void Handle(MyTimeout message)
    {
        Debug.WriteLine(Data.MyProp);
    }
}