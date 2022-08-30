using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Streamye.DesignPattern.DesignPrinciples.DependencyInverse;

namespace Microsoft.Streamye.DesignPrinciples.OpenClose
{
    public class PayFactory
    {
        private IDictionary<string, string> payDic = new Dictionary<string, string>();

        public PayFactory(IConfiguration configuration)
        {
            //1.加载json
            var shapesSection = configuration.GetSection("payType");
            
            //2. 存储支付类型
            foreach (IConfigurationSection section in shapesSection.GetChildren())
            {
                var key = section.GetValue<string>("Key");
                var value = section.GetValue<string>("Value");
                payDic[key] = value;
            }
        }

        public IPay GetPay(string payType)
        {
            if (payType.Equals("WX"))
            {
                return new WXPay();
            }else if (payType.Equals("Ali"))
            {
                return new AliPay();
            }else if (payType.Equals("MS"))
            {
                return new MSPay();
            }
            //问题：新类型加进来又不符合开闭原则
            
            string payTypeString = payDic[payType];
            if (payTypeString == null || payTypeString.Equals(""))
            {
                return null;
            }
            
            //反射构造对象
            Type type = Type.GetType(payTypeString, true, true);
            return (IPay)Activator.CreateInstance(type);
            
            // return null;
        }
        
        
    }
}