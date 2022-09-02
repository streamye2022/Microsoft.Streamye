using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Streamye.DesignPattern.Builder;
using Microsoft.Streamye.DesignPattern.Builder.component;
using Microsoft.Streamye.DesignPattern.Builder.component.Impl;
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

            #region IOC容器

            IOCFactory iocFactory = new IOCFactory();
            Object o = iocFactory.GetObject<Canon>();

            #endregion

            #region 构造者模式
                
            //正常操作：
            AbstractCPU cpu = new MSCPU();
            //AbstractCPU cpu = new MSCPU(arg1,arg2,arg3...arg10);
            AbstractFrame frame = new MSFrame();
            AbstractMemory memory = new MSMemory();
            Computer computer = new Computer();
            computer.Cpu = cpu;
            computer.Frame = frame;
            computer.Memory = memory;
            //问题：1.客户端代码会非常多，如果cpu和frame和memory都需要10个零部件，那么这段代码就会非常复杂 =》 封装
            
            
            IComputerBuilder computerBuilder = new ComputerBuilder();
            Computer computer1 = computerBuilder.BuildMemory().BuildFrame().BuildCPU().Build();
            //何时用抽象类或者接口？ 1.一般关注对象，则用抽象类（CPU,Memory,Frame） 2.如果不关心对象的属性，只关心对象的行为，用接口；
            
            // 真实案例：
            IConfigurationBuilder Builder = new ConfigurationBuilder();
            // 加载json文件
            // 好处：
            // 1.json,xml,ini,我都不care,而且你完全自己的实现自己的代码，跟我的IConfigurationBuilder丝毫没有耦合
            // 2.如果json的实现有多复杂，那是json的 JsonConfigurationProvider的问题
            Builder.AddJsonFile("appsettings.json");
            // 创建配置对象
            IConfiguration configuration = Builder.Build();
            //IHostBuilder
            //IApplicationBuilder

            #endregion
        }
        
    }
}