namespace Microsoft.Streamye.DesignPattern.Observer.Impl
{
    public class Baby : IObservable
    {

        public string Health {
            set
            {
                if (value.Equals("生病"))
                {
                    Event @event = new Event();
                    @event.message = "生病";
                    Send(@event);
                }
            }
        }

        public void Cry()
        {
            Event @event = new Event();
            @event.message = "cry";

            //问题：baby不想持有observers
            Send(@event);
        }
    }
}