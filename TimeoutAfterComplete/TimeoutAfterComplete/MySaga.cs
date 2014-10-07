using System;
using System.Collections.Generic;
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
        Debug.WriteLine(Data.MyProp);
    }

    public void Handle(MyTimeout message)
    {
        Debug.WriteLine(Data.MyProp);
    }

}