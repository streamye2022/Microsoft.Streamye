using System;
using Microsoft.Streamye.DesignPattern.WebAPI.Attributes;

namespace Microsoft.Streamye.DesignPattern.WebAPI
{
    
    [ApiController("canary")]
    public class CanaryCheckController
    {
        [Router("checkvm")]
        public void CheckVM()
        {
            Console.WriteLine("check vm");
        }
    }
}