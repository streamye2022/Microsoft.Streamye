using System;

namespace Microsoft.Streamye.DesignPattern.DesignPrinciples.DependencyInverse
{
    public class WXPay :IPay
    {
        public void CreatePay()
        {
            Console.WriteLine("腾讯pay");
        }
    }
}