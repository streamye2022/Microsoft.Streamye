namespace Microsoft.Streamye.DesignPattern.Decorator
{
    public class AbstractCMDPayDecorator
    {
        protected IPay _pay;
        
        public AbstractCMDPayDecorator(IPay pay)
        {
            this._pay = pay;
        }
    }
}