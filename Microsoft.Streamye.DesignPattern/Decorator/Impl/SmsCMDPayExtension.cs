using System;

namespace Microsoft.Streamye.DesignPattern.Decorator.Impl
{
    public static class SmsCMDPayExtension
    {
        public static void SendSms(this IPay cmdPay)
        {
            Console.WriteLine("send sms");
        }
    }
}