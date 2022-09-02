using System;

namespace Microsoft.Streamye.DesignPattern.Chain.Manager
{
    public class EVPManager : AbstractManager
    {
        private int HandleMoney = 1000 * 1000 * 1000;
        public override void AuditProduct(ProductAuditRequest request)
        {
            if (request.Money <= HandleMoney)
            {
                Console.WriteLine("EVP audit success");
                return;
            }
            
            // _abstractManager.AuditProduct(request);
            if (null != NextAbstractManager)
            {
                NextAbstractManager.AuditProduct(request);
            }
        }
    }
}