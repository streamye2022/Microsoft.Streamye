using System;

namespace Microsoft.Streamye.DesignPattern.IOC.Strategy
{
    public class ActivatorObjectCreateStrategy: IObjectCreateStrategy
    {
        public object CreateObject(Type type)
        {
            return  Activator.CreateInstance(type);
        }
    }
}