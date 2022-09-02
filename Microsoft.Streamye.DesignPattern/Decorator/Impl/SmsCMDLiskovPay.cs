using System;

namespace Microsoft.Streamye.DesignPattern.Decorator.Impl
{
    public class SmsCMDLiskovPay: CMDPay
    {
        public override void Pay()
        {
            base.Pay(); // 覆盖有风险
            SendSms();
        }
        
        private void SendSms()
        {
            Console.WriteLine("send sms");
        }
    }
}