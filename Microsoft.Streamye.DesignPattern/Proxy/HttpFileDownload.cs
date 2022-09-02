using System;

namespace Microsoft.Streamye.DesignPattern.Proxy
{
    public class HttpFileDownload : IFileDownLoad
    {
        public void Download()
        {
            Console.WriteLine("http file download");
        }
    }
}