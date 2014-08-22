using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using NServiceBus;
using NServiceBus.Installation.Environments;

namespace API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static readonly bool NserviceBusIsTransactional = false;
        private IBus Bus { get; set; }
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Configure.Serialization.Xml();
            if (NserviceBusIsTransactional)
            {
                Configure.Transactions.Enable();
            }
            else
            {
                Configure.Transactions.Disable();
            }

            try
            {
                Bus = Configure.With()

                    .Log4Net()
                    .DefaultBuilder()

                    .UseTransport<Msmq>()
                    .MsmqSubscriptionStorage()
                    .DisableTimeoutManager()
                    .PurgeOnStartup(true)
                    .UnicastBus()
                    .ImpersonateSender(false)
                    .CreateBus()

                    .Start(() => Configure.Instance.ForInstallationOn<Windows>().Install());


                OrgCallbacksManager.Bus = Bus;
            }
            catch (Exception ex)
            {
                if (ex is System.Reflection.ReflectionTypeLoadException)
                {
                    var typeLoadException = ex as ReflectionTypeLoadException;
                    var loaderExceptions = typeLoadException.LoaderExceptions;
                }
                //LogFacade.Fatal("Error configuring NserviceBus", ex);

            }

        }
    }

    public class OrgCallbacksManager
    {
        public static IBus Bus { get; set; }
    }
}
