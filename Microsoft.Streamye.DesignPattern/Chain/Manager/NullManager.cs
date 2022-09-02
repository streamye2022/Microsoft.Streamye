using System;

namespace Microsoft.Streamye.DesignPattern.Chain.Manager
{
    public class NullManager : AbstractManager
    {
        public override void AuditProduct(ProductAuditRequest request)
        {
            Console.WriteLine("do nothing");
            if (null != NextAbstractManager)
            {
                NextAbstractManager.AuditProduct(request);
            }
        }
    }
}