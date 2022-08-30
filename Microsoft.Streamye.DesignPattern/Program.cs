using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Streamye.DesignPattern.Factory;

namespace Microsoft.Streamye.DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 工厂模式
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("shape.json", false, true);
            var configurationRoot = configBuilder.Build();

            var services = new ServiceCollection();
            services.AddSingleton<ShapeFactory>();
            services.AddSingleton<IConfiguration>(configurationRoot);

            var serviceProvider=services.BuildServiceProvider();

            var shapeFactory= serviceProvider.GetService<ShapeFactory>();
            shapeFactory.getShage("circle").Draw();
            #endregion
           
        }
        
    }
}