using System;

namespace Microsoft.Streamye.DesignPattern.Decorator.Impl
{
    // public class SmsCMDPayDecorator : AbstractCMDPayDecorator,IPay
    public class SmsCMDPayDecorator : IPay
    {
        private IPay _pay;
        public SmsCMDPayDecorator(IPay pay)
        {
            _pay = pay;
        }
        // public SmsCMDPayDecorator(IPay pay) : base(pay)
        // {
        // }

        public void Pay()
        {
           _pay.Pay();
           SendSms();
        }

        private void SendSms()
        {
            Console.WriteLine("send sms");
        }
    }
}