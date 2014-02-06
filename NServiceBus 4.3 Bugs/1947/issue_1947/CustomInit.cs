using System;


namespace ClassLibrary6
{
    using NServiceBus;
    public class CustomInit : INeedInitialization
    {
        public void Init()
        {
            throw new Exception("Really bad!!");
        }
    }
}
