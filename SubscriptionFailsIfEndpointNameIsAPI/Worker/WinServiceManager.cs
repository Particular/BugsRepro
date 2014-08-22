using System;
using Common;
using NServiceBus;
using NServiceBus.Installation.Environments;

namespace Worker
{
    public class WinServiceManager
    {
        public static string SERVICE_NAME;
        private static readonly bool NserviceBusIsTransactional = false;


        static WinServiceManager()
        {

            try
            {
                SERVICE_NAME = "worker";

            }
            catch (Exception ex)
            {
                //LogFacade.Fatal(SERVICE_NAME, ex);
                throw;
            }

        }

        private IBus Bus { get; set; }

        public bool Start()
        {
            try
            {
                Configure.Serialization.Xml();
                if (NserviceBusIsTransactional)
                {
                    Configure.Transactions.Enable();
                }
                else
                {
                    Configure.Transactions.Disable().Advanced(s => { s.DisableDistributedTransactions(); s.DoNotWrapHandlersExecutionInATransactionScope(); });
                }

                Bus = Configure.With()
                    .DefineEndpointName("Worker")
                    .Log4Net()
                    .DefaultBuilder()
                    .UseTransport<Msmq>()
                    .MsmqSubscriptionStorage()
                    .DisableTimeoutManager()
                    .PurgeOnStartup(false)
                    .UnicastBus()
                    .ImpersonateSender(false)
                    .CreateBus()
                    .Start(() => Configure.Instance.ForInstallationOn<Windows>().Install());

                Bus.Subscribe<INewMissionMessage>();

                return true;
            }
            catch (Exception ex)
            {
                //LogFacade.Fatal(SERVICE_NAME, ex);
                return false;
            }
        }


        public bool Stop()
        {
            try
            {
                //LogFacade.Info(SERVICE_NAME + string.Format("{0} {1} Stopped", System.Net.Dns.GetHostName(), SERVICE_NAME));
                //bus.Unsubscribe<IStatusChangedMessage>(); ///-->> throws exception, why??
                return true;
            }
            catch (Exception ex)
            {
                //LogFacade.Fatal(SERVICE_NAME, ex);
                return false;
            }
        }
    }
}