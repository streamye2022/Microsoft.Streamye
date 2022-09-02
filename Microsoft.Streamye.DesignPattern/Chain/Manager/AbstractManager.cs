namespace Microsoft.Streamye.DesignPattern.Chain.Manager
{
    public abstract class AbstractManager
    {
        public AbstractManager NextAbstractManager;
        
        public abstract void AuditProduct(ProductAuditRequest request);
    }
}