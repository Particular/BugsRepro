using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using NServiceBus;
using NServiceBus.Installation.Environments;
using Topshelf;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            HostFactory.New(x => x.Service<WinServiceManager>(sc =>
            {
                sc.ConstructUsing(() => new WinServiceManager());

                sc.WhenStarted(s => s.Start());
                sc.WhenStopped(s => s.Stop());
                x.RunAsLocalSystem();

                x.SetDescription(WinServiceManager.SERVICE_NAME + "Topshelf Host");
                x.SetDisplayName(WinServiceManager.SERVICE_NAME);
                x.SetServiceName(WinServiceManager.SERVICE_NAME);

            })).Run();


        }
    }
}
