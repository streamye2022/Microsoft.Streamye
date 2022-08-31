namespace Microsoft.Streamye.DesignPrinciples.InterfaceIsolation
{
    public class AbstractPay: IPay2
    {
        public void CreatePay()
        {
            throw new System.NotImplementedException();
        }

        public void PayCount()
        {
            throw new System.NotImplementedException();
        }
    }
}