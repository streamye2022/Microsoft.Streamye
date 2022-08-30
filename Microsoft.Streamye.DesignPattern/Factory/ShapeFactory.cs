using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Streamye.DesignPattern.Factory.Shapes;

namespace Microsoft.Streamye.DesignPattern.Factory
{
    public class ShapeFactory
    {
        private IDictionary<string, string> keyvalues = new Dictionary<string, string>();
        
        public ShapeFactory(IConfiguration configuration)
        {
            //加载json
            var shapesSection = configuration.GetSection("shapes");
            foreach (IConfigurationSection section in shapesSection.GetChildren())
            {
                var key = section.GetValue<string>("Key");
                var value = section.GetValue<string>("Value");
                keyvalues[key] = value;
            }

        }
        
        public IShape getShage(string shapeType)
        {
            // if else
            
            //读取map
            string shapeString = keyvalues[shapeType];
            if (shapeString == null || shapeString.Equals(""))
            {
                return null;
            }
            
            //反射构造对象
            Type type = Type.GetType(shapeString, true, true);
            return (IShape)Activator.CreateInstance(type);
        }
        
        private class KVPair
        {
            public string Key;
            public string Value;
        }
    }
}