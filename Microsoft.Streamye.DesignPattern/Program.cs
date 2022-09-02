using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Streamye.DesignPattern.Builder;
using Microsoft.Streamye.DesignPattern.Builder.component;
using Microsoft.Streamye.DesignPattern.Builder.component.Impl;
using Microsoft.Streamye.DesignPattern.Chain;
using Microsoft.Streamye.DesignPattern.Chain.Manager;
using Microsoft.Streamye.DesignPattern.Decorator;
using Microsoft.Streamye.DesignPattern.Decorator.Impl;
using Microsoft.Streamye.DesignPattern.Factory;
using Microsoft.Streamye.DesignPattern.IOC;
using Microsoft.Streamye.DesignPattern.IOC.Services;
using Microsoft.Streamye.DesignPattern.Strategy;

namespace Microsoft.Streamye.DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            // #region 工厂模式
            // var configBuilder = new ConfigurationBuilder();
            // configBuilder.AddJsonFile("shape.json", false, true);
            // var configurationRoot = configBuilder.Build();
            //
            // var services = new ServiceCollection();
            // services.AddSingleton<ShapeFactory>();
            // services.AddSingleton<IConfiguration>(configurationRoot);
            //
            // var serviceProvider=services.BuildServiceProvider();
            //
            // var shapeFactory= serviceProvider.GetService<ShapeFactory>();
            // shapeFactory.getShage("circle").Draw(); //1.命令行参数 2.配置文件中读
            // #endregion

            // #region 策略模式
            //
            // IStrategy strategy = new AddStrategy();
            // Arithmetic arithmetic = new Arithmetic(strategy);
            // Console.WriteLine(arithmetic.doMath(5, 3));
            //
            // //问题：客户端得创建这个strategy , 不符合开闭原则 =》 工厂模式 , 策略被使用的时候是一种行为（策略模式），但是这种策略本身又是一个对象（工厂模式）
            // StrategyFactory strategyFactory = new StrategyFactory();
            // IStrategy strategy1 = strategyFactory.GetStrategy(args[1]); //命令行参数中读，或者配置文件中读
            // // Arithmetic arithmetic = new Arithmetic(strategy1);
            //
            // #endregion

            // #region IOC容器
            //
            // IOCFactory iocFactory = new IOCFactory();
            // Object o = iocFactory.GetObject<Canon>();
            //
            // #endregion

            // #region 构造者模式
            //     
            // //正常操作：
            // AbstractCPU cpu = new MSCPU();
            // //AbstractCPU cpu = new MSCPU(arg1,arg2,arg3...arg10);
            // AbstractFrame frame = new MSFrame();
            // AbstractMemory memory = new MSMemory();
            // Computer computer = new Computer();
            // computer.Cpu = cpu;
            // computer.Frame = frame;
            // computer.Memory = memory;
            // //问题：1.客户端代码会非常多，如果cpu和frame和memory都需要10个零部件，那么这段代码就会非常复杂 =》 封装
            //
            //
            // IComputerBuilder computerBuilder = new ComputerBuilder();
            // Computer computer1 = computerBuilder.BuildMemory().BuildFrame().BuildCPU().Build();
            // //何时用抽象类或者接口？ 1.一般关注对象，则用抽象类（CPU,Memory,Frame） 2.如果不关心对象的属性，只关心对象的行为，用接口；
            //
            // // 真实案例：IConfigurationBuilder
            // IConfigurationBuilder Builder = new ConfigurationBuilder();
            // // 加载json文件
            // // 好处：
            // // 1.json,xml,ini,我都不care,而且你完全自己的实现自己的代码，跟我的IConfigurationBuilder丝毫没有耦合
            // // 2.如果json的实现有多复杂，那是json的 JsonConfigurationProvider的问题
            // Builder.AddJsonFile("appsettings.json");
            // // 创建配置对象
            // IConfiguration configuration = Builder.Build();
            //
            // //其他案例：
            // //IHostBuilder
            // //IApplicationBuilder
            //
            // #endregion
            //
            // #region 装饰器模式
            //
            // IPay pay = new CMDPay();
            // // pay.Pay();
            // //问题：想添加pay完之后 发送短信的功能，不仅发送短信还想发送 邮件
            // //两种方案： 1.继承方式（会有里氏替换问题） 2.组合方式 3.C#独有的拓展方法 4.代理模式
            //
            // IPay pay1 = new SmsCMDPayDecorator(pay);
            // pay1.Pay(); //组合方式：没有覆盖父类，额外的好处：如果又想发短信，又想发邮件
            //
            // IPay pay2 = new MailCMDPayDecorator(pay1); //这种组合的方式
            // pay2.Pay(); 
            //
            // // C#拓展
            // pay.SendSms();
            // // pay.SendMail();
            //
            // //问题：
            // //实例：IServiceCollection, IApplicationBuilder
            //
            // #endregion

            // #region 代理模式
            //
            // //问题：与装饰器模式的区别，不希望暴露底层的实现, 而且可以加强多个对象的功能， 而装饰器更希望自由组装
            //
            // #endregion

            #region 责任链模式

            M1Manager m1Manager = new M1Manager();
            M2Manager m2Manager = new M2Manager();
            CvpManager cvpManager = new CvpManager();
            
            //形成责任链
            m1Manager.NextAbstractManager = m2Manager;
            m2Manager.NextAbstractManager = cvpManager;

            ProductAuditRequest request = new ProductAuditRequest();
            request.Money = 1000*1000*5;
            request.ProductName = "canon";
            
            // m1Manager.AuditProduct(request);
            
            //问题：1. 如果新增一个处理器，则客户端代码得改 =》 List
            //真实情况类似：A权限校验， B权限校验， C权限校验 

            ProductAuditBuilder productAuditBuilder = new ProductAuditBuilder();
            productAuditBuilder.AddM1Manager();
            productAuditBuilder.AddManager(m2Manager);
            productAuditBuilder.AddManager(cvpManager);
            
            //两种拓展的方法 ： 1. client中修改 2. Extension中拓展 ，真实的是在 IOC容器里面拿的对象
            // productAuditBuilder.AddManager(new EVPManager());
            productAuditBuilder.AddEVPManager(); 
            
            ProductAudit productAudit = productAuditBuilder.Build();
            AbstractManager abstractManager = productAudit.GetManager();

            request.Money = 1000*1000*500;
            request.ProductName = "canon2";
            abstractManager.AuditProduct(request);

            //问题：1.why 需要builder来做？ 

            #endregion

        }
        
    }
}