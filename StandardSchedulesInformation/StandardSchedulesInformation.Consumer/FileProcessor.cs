using NServiceBus;
using StandardSchedulesInformation.Consumer.Commands;

namespace StandardSchedulesInformation.Consumer
{
    public class FileProcessor : IHandleMessages<ProcessFile>
    {

        public void Handle(ProcessFile message)
        {
        }
    }
}