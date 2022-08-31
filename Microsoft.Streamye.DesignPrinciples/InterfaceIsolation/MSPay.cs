using System;

namespace Microsoft.Streamye.DesignPrinciples.InterfaceIsolation
{
    // public class MSPay: IPay2
    // public class MSPay :AbstractPay
    public class MSPay :IPay3
    {
        public void CreatePay()
        {
            Console.WriteLine("微软pay");
        }
    }
}