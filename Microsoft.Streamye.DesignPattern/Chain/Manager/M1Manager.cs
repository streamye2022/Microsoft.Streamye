using System;

namespace Microsoft.Streamye.DesignPattern.Chain.Manager
{
    public class M1Manager: AbstractManager
    {
        private int HandleMoney = 1000 * 1000;

        // private AbstractManager _abstractManager;
        public override void AuditProduct(ProductAuditRequest request)
        {
            if (request.Money <= HandleMoney)
            {
                Console.WriteLine("M1 audit success");
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