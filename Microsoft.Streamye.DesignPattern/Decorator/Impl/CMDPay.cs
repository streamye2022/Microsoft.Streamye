using System;

namespace Microsoft.Streamye.DesignPattern.Decorator.Impl
{
    public class CMDPay : IPay
    {
        public CMDPay()
        {
        }

        public virtual void Pay()
        {
            Console.WriteLine("cmd pay");
        }
    }
}