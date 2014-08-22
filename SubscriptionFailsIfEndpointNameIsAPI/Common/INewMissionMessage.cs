using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Common
{
    public interface INewMissionMessage : IMessage
    {
        DateTime CreationTime { get; set; }
        string Message { get; set; }
    }
}
