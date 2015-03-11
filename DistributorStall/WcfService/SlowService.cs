using System.Threading;

namespace WcfService
{
    class SlowService : ISlowService
    {
        public string Greet(string name)
        {
            Thread.Sleep(10000);
            return "Hello, " + name + "!";
        }
    }
}