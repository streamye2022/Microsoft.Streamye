namespace Microsoft.Streamye.DesignPattern.Observer
{
    public abstract class Event2
    {
        public object source { get; }

        protected Event2(object source)
        {
            this.source = source;
        }
    }
}