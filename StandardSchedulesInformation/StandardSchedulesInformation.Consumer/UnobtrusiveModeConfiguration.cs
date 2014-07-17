using NServiceBus;

namespace StandardSchedulesInformation.Consumer
{
    public class UnobtrusiveModeConfiguration : IWantToRunBeforeConfiguration
    {
        public void Init()
        {
            Configure.Instance
                .DefiningCommandsAs(
                    c =>
                        c.Namespace != null && c.Namespace.StartsWith("StandardSchedulesInformation") &&
                        c.Namespace.EndsWith("Commands"))
                .DefiningMessagesAs(
                    c =>
                        c.Namespace != null && c.Namespace.StartsWith("StandardSchedulesInformation") &&
                        c.Namespace.EndsWith("Messages"))
                .DefiningEventsAs(
                    c =>
                        c.Namespace != null && c.Namespace.StartsWith("StandardSchedulesInformation") &&
                        c.Namespace.EndsWith("Events"));
        }
    }
}