using System;

namespace Microsoft.Streamye.DesignPattern.IOC.Strategy
{
    public class AssemlyObjectCreateStrategy : IObjectCreateStrategy
    {
        public object CreateObject(Type type)
        {
            return type.Assembly.CreateInstance(type.FullName);
        }
    }
}