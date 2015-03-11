using System.ServiceModel;

namespace WcfService
{
    [ServiceContract]
    public interface ISlowService
    {
        [OperationContract]
        string Greet(string name);
    }
}