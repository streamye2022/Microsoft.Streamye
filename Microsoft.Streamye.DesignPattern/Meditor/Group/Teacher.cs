using System;

namespace Microsoft.Streamye.DesignPattern.Meditor.Group
{
    public class Teacher : AbstractPeople,IPeople
    {
        public void Receive(string message)
        {
            Console.WriteLine("teacher revice:"+ message);
        }

        public void Send(string message)
        {
            Console.WriteLine("teacher send:"+ message);
            Meditor.Send(message);
        }
    }
}