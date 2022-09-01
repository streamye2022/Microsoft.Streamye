using System;
using Microsoft.Streamye.DesignPattern.IOC.Attribute;

namespace Microsoft.Streamye.DesignPattern.IOC.Services
{
    [IOCService]
    [Scope]
    public class MS
    {
        [IOCInject]
        public CMD Cmd { get; set; }
        
        [AOP]
        public void publish()
        {
            Console.WriteLine("发布新品");
        }
    }
}