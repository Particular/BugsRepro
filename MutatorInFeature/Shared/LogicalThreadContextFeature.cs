using NServiceBus;
using NServiceBus.Features;

public class LogicalThreadContextFeature : Feature
{
    internal LogicalThreadContextFeature()
    {
        EnableByDefault();
    }

    protected override void Setup(FeatureConfigurationContext context)
    {
        context.Container.ConfigureComponent(typeof(LogicalThreadContextMutator), DependencyLifecycle.InstancePerCall);
    }
}