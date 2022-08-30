using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Streamye.DesignPrinciples.DemeteRule;
using Microsoft.Streamye.DesignPrinciples.OpenClose;

namespace Microsoft.Streamye.DesignPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 面向过程案例 问题：1. 不关心具体的调用过程？ 2. 订单要做删除，更新，查询怎么办？ 
            //选择商品
            ChooseProduct();
            //创建订单
            CreateOrder();
            //扣减库存
            SubStock();
            //创建支付
            CreatePay();
            #endregion

            #region 迪米特法则, 知道的越少越好，对应到 facade模式, 黑盒, 单一职责原则
            // var eBusiness = new EBusiness();
            // eBusiness.BuyGoods();
            
            // 问题：1. 如果我现在想换支付方式？ 
            #endregion

            #region 开闭原则
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("pay.json", false, true);
            var configurationRoot = configBuilder.Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configurationRoot);
            services.AddSingleton<PayFactory>();
            services.AddSingleton<EBusiness>();
            

            var serviceProvider=services.BuildServiceProvider();

            var eBusiness = serviceProvider.GetService<EBusiness>();
            eBusiness.BuyGoods("WX");

            #endregion
           
        }
        static void ChooseProduct()
        {
            Console.WriteLine("选择商品");
        }
        
        static void CreateOrder()
        {
            Console.WriteLine("创建订单");
        }
        static void SubStock()
        {
            Console.WriteLine("扣减库存");
        }
        static void CreatePay()
        {
            Console.WriteLine("创建支付");
        }
    }
}