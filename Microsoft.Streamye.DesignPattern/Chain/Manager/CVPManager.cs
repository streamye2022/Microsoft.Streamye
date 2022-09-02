using System;

namespace Microsoft.Streamye.DesignPattern.Chain.Manager
{
    public class CvpAbstractManager : AbstractManager
    {
        private int HandleMoney = 1000 * 1000 * 100;

        // private AbstractManager _abstractManager;
        public override void AuditProduct(ProductAuditRequest request)
        {
            if (request.Money <= HandleMoney)
            {
                Console.WriteLine("CVP audit success");
                return;
            }
            
            // _abstractManager.AuditProduct(request);
            NextAbstractManager.AuditProduct(request);
        }
    }
}