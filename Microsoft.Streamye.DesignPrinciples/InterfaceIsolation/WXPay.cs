using System;

namespace Microsoft.Streamye.DesignPrinciples.InterfaceIsolation
{
    // public class WXPay :IPay2
    // public class WXPay :AbstractPay
    public class WXPay : IPay2, IPayCount
    {
        public void CreatePay()
        {
            Console.WriteLine("腾讯pay");
        }
        public void PayCount()
        {
            Console.WriteLine("腾讯paycount");
        }
    }
}