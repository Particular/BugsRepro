using System;
using Messages;
using Messages.Commands;
using NServiceBus;

namespace Client
{
    public class CommandSender : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            int documentInstance = 1;
        
            while (Console.ReadLine() != null)
            {
            
                var name = string.Format("AccountNumber: {0}", documentInstance);

                Bus.Send<ProcessLoanDocumentCommand>(c =>
                {
                    c.DocumentName = name;
                    
                });
                Console.WriteLine("Sent loan instance " + name);

                Bus.Send<ProcessLienDocumentCommand>(c =>
                {
                    c.DocumentName = name;
                
                });
                Console.WriteLine("Sent lien instance " + name);
                documentInstance++;
            }
        }

        public void Stop()
        {
        }
    }
}