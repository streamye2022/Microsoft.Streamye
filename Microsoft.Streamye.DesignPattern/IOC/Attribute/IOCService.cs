using System;

namespace Microsoft.Streamye.DesignPattern.IOC.Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class IOCService : System.Attribute
    {
        public IOCService()
        {
        }
    }
}