using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NServiceBus;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;
using NServiceBus.Logging;

namespace WebApplication1
{
    public class MvcApplication : HttpApplication
    {
        IStartableBus startableBus;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var busConfiguration = new BusConfiguration();
            busConfiguration.UsePersistence<InMemoryPersistence>();
            startableBus = Bus.Create(busConfiguration);
            startableBus.Start();
            startableBus.SendLocal(new MyMessage());
        }
    }

    public class MyMessage:IMessage
    {
    }

    public class MyHandler : IHandleMessages<MyMessage>
    {
        static readonly ILog Log = LogManager.GetLogger(typeof(MyHandler)); 
        public void Handle(MyMessage message)
        {
            Log.Error("The error");
        }
    }
    class ConfigErrorQueue : IProvideConfiguration<MessageForwardingInCaseOfFaultConfig>
    {
        public MessageForwardingInCaseOfFaultConfig GetConfiguration()
        {
            return new MessageForwardingInCaseOfFaultConfig
            {
                ErrorQueue = "error"
            };
        }
    }
}


