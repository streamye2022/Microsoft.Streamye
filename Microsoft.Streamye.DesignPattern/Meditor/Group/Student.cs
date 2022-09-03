using System;

namespace Microsoft.Streamye.DesignPattern.Meditor.Group
{
    public class Student: AbstractPeople,IPeople
    {
        public void Receive(string message)
        {
            Console.WriteLine("student revice:"+ message);
        }

        public void Send(string message)
        {
            Console.WriteLine("student send:"+ message);
            Meditor.Send(message);
        }
    }
}