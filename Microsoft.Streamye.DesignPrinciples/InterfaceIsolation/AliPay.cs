using System;

namespace Microsoft.Streamye.DesignPrinciples.InterfaceIsolation
{
    // public class AliPay : IPay2
    // public class AliPay : AbstractPay
    public class AliPay :IPay3, IPayCount
    {
        public void CreatePay()
        {
            Console.WriteLine("阿里pay");
        }
        
        public void PayCount()
        {
            Console.WriteLine("阿里paycount");
        }
    }
}