using System;

namespace Microsoft.Streamye.DesignPrinciples.DependencyInverse
{
    public class AliPay : IPay
    {
        public void CreatePay()
        {
            Console.WriteLine("阿里pay");
        }
    }
}