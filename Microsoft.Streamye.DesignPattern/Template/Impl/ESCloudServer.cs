using System;

namespace Microsoft.Streamye.DesignPattern.Template.Impl
{
    // public class ESCloudServer : ICloudServer
    public class ESCloudServer : AbstractCloudServer
    {
        // protected void OpenFile()
        protected override void OpenFile()
        {
            Console.WriteLine("open file");
        }

        protected override void Connection()
        {
            Console.WriteLine("http connect");
        }

        protected override void Serialize()
        {
            Console.WriteLine("serilize xml");
        }

        protected override void Transport()
        {
            Console.WriteLine("transport");
        }
    }
}