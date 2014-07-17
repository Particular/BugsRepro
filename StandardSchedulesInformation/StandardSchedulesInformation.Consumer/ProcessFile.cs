using System;

namespace StandardSchedulesInformation.Consumer.Commands
{
    public class ProcessFile
    {
        public ProcessFile(string fullPath, string name, Guid id)
        {
            FullPath = fullPath;
            Name = name;
            Id = id;
        }

        public string FullPath { get; private set; }
        public string Name { get; private set; }
        public Guid Id { get; private set; }
    }
}