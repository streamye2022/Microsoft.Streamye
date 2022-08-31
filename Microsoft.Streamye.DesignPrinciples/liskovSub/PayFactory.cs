using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Streamye.DesignPrinciples.DependencyInverse;

namespace Microsoft.Streamye.DesignPrinciples.liskovSub
{ 
    public class PayFactory
    {
        private IDictionary<string, string> payDic = new Dictionary<string, string>();

        private int count;
        
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

        //sealed 方式被重写
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

            count++;
            
            //反射构造对象
            Type type = Type.GetType(payTypeString, true, true);
            return (IPay)Activator.CreateInstance(type);
            
            // return null;
        }
        
        
    }
}