using System;
using Microsoft.Streamye.DesignPattern.WebApiMiddleware.Chains;

namespace Microsoft.Streamye.DesignPattern.Template.Impl
{
    // public class KustoCloudServer : ICloudServer
    public class KustoCloudServer : AbstractCloudServer
    {
        protected override void OpenFile()
        {
            Console.WriteLine("open file");
        }

        protected override void Connection()
        {
            Console.WriteLine("grpc connect");
        }

        protected override void Serialize()
        {
            Console.WriteLine("serilize json");
        }

        protected  override void Transport()
        {
            Console.WriteLine("transport");
        }
        
    }
}