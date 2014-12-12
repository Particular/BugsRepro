using System;
using NServiceBus;
using NServiceBus.Logging;

public class MyHandler : IHandleMessages<MyMessage>
{
    static ILog Logger = LogManager.GetLogger(typeof(MyHandler));
    static int count;
    public void Handle(MyMessage message)
    {
        if (count == 10)
        {
            Logger.Info("Failed 10 times so now we succeed " + DateTime.Now);
      
            return;
        }
        count++;
        throw new Exception("TheException " + count);
    }
}