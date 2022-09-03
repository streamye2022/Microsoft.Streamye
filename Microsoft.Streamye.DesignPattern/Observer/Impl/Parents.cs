using System;

namespace Microsoft.Streamye.DesignPattern.Observer.Impl
{
    public class Parents : IObserver
    {
        public void Receive(Event @event)
        {
            Console.WriteLine("parents recevie:" + @event.message);
        }
    }
}