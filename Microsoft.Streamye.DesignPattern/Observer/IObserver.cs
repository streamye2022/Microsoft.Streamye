namespace Microsoft.Streamye.DesignPattern.Observer
{
    public interface IObserver
    {
        public void Receive(Event @event);
    }
}