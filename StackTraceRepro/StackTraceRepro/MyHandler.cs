using System;
using NServiceBus;

namespace StackTraceRepro
{
    class MyHandler:IHandleMessages<MyMessage>
    {
        public void Handle(MyMessage message)
        {
            ClassThaThrows.MethodThatThrows();
        }
    }

    class ClassThaThrows
    {
        public static void MethodThatThrows()
        {
            MethodThatThrows2();
        }

        static void MethodThatThrows2()
        {
            throw new MyException("Foo Bar");
        }
    }

    class MyException : Exception
    {
        public MyException(string message)
            : base(message)
        {
            
        }
    }

    class MyMessage:IMessage
    {
    }
}
