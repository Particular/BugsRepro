using Ninject;
using NServiceBus;

namespace StandardSchedulesInformation.Consumer
{
    public class NinjectConfiguration : INeedInitialization
    {
        public void Init()
        {
            var kernel = new StandardKernel();
            kernel.Load(GetType().Assembly);

            Configure.With().NinjectBuilder(kernel);
        }
    }
}