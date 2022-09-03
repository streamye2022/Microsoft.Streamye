namespace Microsoft.Streamye.DesignPattern.Iterator
{
    public interface IIterator
    {
        public bool HasNext();

        public string Next();
    }
}