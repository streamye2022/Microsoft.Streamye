using System;

namespace Microsoft.Streamye.DesignPattern.Meditor.Group
{
    public class Parent : AbstractPeople, IPeople
    {
        public void Receive(string message)
        {
            Console.WriteLine("parent revice:" + message);
        }

        public void Send(string message)
        {
            Console.WriteLine("parent send:" + message);
            Meditor.Send(message);
        }
    }
}