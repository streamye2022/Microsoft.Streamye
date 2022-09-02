using System;

namespace Microsoft.Streamye.DesignPattern.Decorator.Impl
{
    public class MailCMDPayDecorator :IPay
    {
        
        private IPay _pay;

        public MailCMDPayDecorator(IPay pay)
        {
            this._pay = pay;
        }

        public void Pay()
        {
            _pay.Pay();
            SendMail();
        }
        
        //问题：构造函数和属性是一样的？？
        private void SendMail()
        {
            Console.WriteLine("send mail"); 
        }
    }
}