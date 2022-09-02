using Microsoft.Streamye.DesignPattern.Builder.component;
using Microsoft.Streamye.DesignPattern.Chain.Manager;

namespace Microsoft.Streamye.DesignPattern.Chain
{
    public class ProductAuditBuilder
    {
        private ProductAudit _productAudit = new ProductAudit();

        public void AddM1Manager()
        {
            M1Manager manager = new M1Manager();
            _productAudit.AddManager(manager);
        }

        public void AddManager(AbstractManager manager)
        {
            _productAudit.AddManager(manager);
        }

        public ProductAudit Build()
        {
            return _productAudit;
        }
    }
}