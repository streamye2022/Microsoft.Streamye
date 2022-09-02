using Microsoft.Streamye.DesignPattern.Chain.Manager;

namespace Microsoft.Streamye.DesignPattern.Chain
{
    public abstract class AbstractManager
    {
        public AbstractManager NextAbstractManager;
        
        public abstract void AuditProduct(ProductAuditRequest request);
    }
}