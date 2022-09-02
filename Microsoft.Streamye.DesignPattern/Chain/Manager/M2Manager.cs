using System;

namespace Microsoft.Streamye.DesignPattern.Chain.Manager
{
    public class M2Manager : AbstractManager
    {
        private int HandleMoney = 1000 * 1000 * 10;

        // private AbstractManager _abstractManager; // 每个人都有这个
        public override void AuditProduct(ProductAuditRequest request)
        {
            if (request.Money <= HandleMoney)
            {
                Console.WriteLine("M2 audit success");
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