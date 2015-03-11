using System;
using System.ServiceModel;

namespace WcfService
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof (SlowService));
            host.AddServiceEndpoint(typeof (ISlowService), new BasicHttpBinding(), "http://localhost:6666/Greeter");
            host.Open();

            Console.WriteLine("Press <enter> to exit");
            Console.ReadLine();

            host.Close();
        }
    }
}
