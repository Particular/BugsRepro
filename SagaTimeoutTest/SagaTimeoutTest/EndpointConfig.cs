namespace SagaTimeoutTest
{
    using NServiceBus;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/

    [EndpointName("SagaPeristenceUsingRavenDB")]
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
    }

     class MessageConventions : IWantToRunBeforeConfiguration
     {
         public void Init()
         {
             Configure.Instance.DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith("Commands"));
         }
     }
}
