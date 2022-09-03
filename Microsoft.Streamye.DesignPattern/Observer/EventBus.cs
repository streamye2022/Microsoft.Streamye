using System.Collections.Generic;

namespace Microsoft.Streamye.DesignPattern.Observer
{
    public class EventBus
    {
        private IList<IEventHandler> _list = new List<IEventHandler>();

        public void AddObserver(IEventHandler observer)
        {
            _list.Add(observer);
        }

        public void RemoveObserver(IEventHandler observer)
        {
            _list.Remove(observer);
        }

        public void PublishEvent(Event2 @event)
        {
            foreach (var observer in _list)
            {
                observer.OnEvent(@event);
            }
        }
    }
}