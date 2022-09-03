using System;

namespace Microsoft.Streamye.DesignPattern.Observer.Impl
{
    public class GrandParents : IObserver
    {
        public void Receive(Event @event)
        {
            Console.WriteLine("grand parents recevie:" + @event.message);
        }
    }
}