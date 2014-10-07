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
        var dictionary = Bus.CurrentMessageContext.Headers;
        // the timeout will fire but the saga data will be empty
        // have a look in the headers. the timeout is associated with an exiting saga. ie no this one
        //Note the MyProp value here will be 0 and the id will be a new guid
        Debug.WriteLine(Data.MyProp);
    }

    public void Handle(MyTimeout message)
    {
        Debug.WriteLine(Data.MyProp);
    }

}