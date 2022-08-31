using Microsoft.Extensions.Configuration;

namespace Microsoft.Streamye.DesignPrinciples.liskovSub
{
    public class CountPayFactory : PayFactory
    {
        private int count;
        public CountPayFactory(IConfiguration configuration) : base(configuration)
        {
        }

        //有覆盖父类功能的风险
        // public override IPay GetPay(string payType)
        // {
        //     count++;
        //     return new MSPay();
        // }

        public void PayCount(string payType)
        {
            base.GetPay(payType).CreatePay();
            count++;
        }

    }
}