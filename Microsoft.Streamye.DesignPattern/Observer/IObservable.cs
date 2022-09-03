using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Streamye.DesignPattern.Observer
{
    // 被观察者
    public abstract class IObservable
    {
        private IList<IObserver> _list = new List<IObserver>();
        
        public void AddObserver(IObserver observer)
        {
            _list.Add(observer);
        }
        
        public void Send(Event @event)
        {
            foreach (var observer in _list)
            {
                observer.Receive(@event);
            }
        }
    }
}