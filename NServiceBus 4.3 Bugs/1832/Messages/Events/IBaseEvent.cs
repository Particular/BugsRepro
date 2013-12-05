using System;

namespace Messages.Events
{
    public interface IBaseEvent
    {
        string Name { get; set; }
    }
}
