using System;

namespace Microsoft.Streamye.DesignPattern.IOC.Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Scope : System.Attribute
    {
        public Scope()
        {
        }
    }
}