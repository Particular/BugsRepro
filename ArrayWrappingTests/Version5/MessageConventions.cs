using NServiceBus;

public static class MessageConventions
{
    public static void ApplyMessageConventions(this Configure configure)
    {
        configure.DefiningCommandsAs(t => t.Namespace == "Common" && t.Name.EndsWith("Command"));
        configure.DefiningEventsAs(t => t.Namespace == "Common" && t.Name.EndsWith("Event"));
        configure.DefiningMessagesAs(t => t.Namespace == "Common" && t.Name.EndsWith("Message"));
    }
}