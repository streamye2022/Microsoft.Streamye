using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        }
        
    }
}