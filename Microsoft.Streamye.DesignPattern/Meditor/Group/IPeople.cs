namespace Microsoft.Streamye.DesignPattern.Meditor.Group
{
    public interface IPeople
    {
        public void Receive(string message);
        public void Send(string message);
    }
}