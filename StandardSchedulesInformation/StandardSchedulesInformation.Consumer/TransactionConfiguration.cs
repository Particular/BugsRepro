using NServiceBus;

namespace StandardSchedulesInformation.Consumer
{
    public class TransactionConfiguration : IWantToRunBeforeConfiguration
    {
        public void Init()
        {
            Configure.Transactions.Advanced(settings => settings.DisableDistributedTransactions());
        }
    }
}