using System;

namespace Microsoft.Streamye.DesignPattern.WebAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ApiController : Attribute
    {
        public string Path { get; }

        public ApiController(string path)
        {
            Path = path;
        }
    }
}