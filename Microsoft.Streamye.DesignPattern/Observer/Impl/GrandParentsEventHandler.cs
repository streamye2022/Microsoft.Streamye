using System;

namespace Microsoft.Streamye.DesignPattern.Observer.Impl
{
    public class GrandParentsEventHandler : IEventHandler
    {
        public void OnEvent(Event2 event2)
        {
            Console.WriteLine("grand parents recevie:" + @event2.source);
        }
    }
}