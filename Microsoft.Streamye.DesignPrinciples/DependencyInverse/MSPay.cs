using System;

namespace Microsoft.Streamye.DesignPrinciples.DependencyInverse
{
    public class MSPay: IPay
    {
        public void CreatePay()
        {
            Console.WriteLine("微软pay");
        }
    }
}