using System;

namespace Microsoft.Streamye.DesignPattern.WebAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class Router : Attribute
    {
        public string Path { get; }

        public Router(string path)
        {
            this.Path = path;
        }
    }
}