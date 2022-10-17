using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Streamye.DesignPrinciples.DemeteRule;
using Microsoft.Streamye.DesignPrinciples.InterfaceIsolation;
using Microsoft.Streamye.DesignPrinciples.liskovSub;
using PayFactory = Microsoft.Streamye.DesignPrinciples.OpenClose.PayFactory;

namespace Microsoft.Streamye.DesignPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 原始code

            Console.WriteLine("选择商品");
            Console.WriteLine("创建订单");
            Console.WriteLine("扣减库存");
            Console.WriteLine("创建支付");
            
            #endregion

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

            #region 面向过程案例 单一职责 问题： 1.我是一个调用者，我不想管这些复杂的东西，给我一个东西就OK
            //选择商品
            var product = new Product();
            product.ChooseProduct();
            //创建订单
            var order = new Order();
            order.CreateOrder();
            //扣减库存
            //创建支付
           
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

            // 问题：我想给IPay加一个功能：统计每个支付的调用量
            // 给Ipay加一个功能，但是MS pay 不想提供这个功能
            #endregion

            #region 接口隔离 ,定义的是一种行为规范, 只关心这种行为
            IPayCount payCount = new WXPay(); //这个时候我只要Paycount这个功能，我不关心Pay
            payCount.PayCount();
            
            // 问题：再加一个功能，统计所有的pay的调用次数
            // 工厂类中加一个功能，1. 直接在工厂中加 2.拓展一个新CountPayFactory

            #endregion

            #region 里氏替换
            //   1.直接在代码中写   2.继承：存在重写的风险  3. 用组合方式的装饰器模式

            // liskovSub.PayFactory payFactory = new liskovSub.PayFactory(configurationRoot);
            liskovSub.PayFactory payFactory = new CountPayFactory(configurationRoot);
            payFactory.GetPay("WX").CreatePay();
            // countPayFactory.PayCount("WX");

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