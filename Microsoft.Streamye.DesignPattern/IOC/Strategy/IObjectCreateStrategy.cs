using System;

namespace Microsoft.Streamye.DesignPattern.IOC.Strategy
{
    public interface IObjectCreateStrategy
    {
        public Object CreateObject(Type type);
    }
}