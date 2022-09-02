using System;

namespace Microsoft.Streamye.DesignPattern.Proxy
{
    public class ProxyFileDownload : IFileDownLoad
    {
        private IFileDownLoad _fileDownLoad;

        public ProxyFileDownload()
        {
            _fileDownLoad = new HttpFileDownload(); // 不建议在参数中传递，因为代理模式更希望不对外暴露底层的东西
        }

        public void Download()
        {
            _fileDownLoad.Download();

            Validate();
        }

        private void Validate()
        {
            Console.WriteLine("validate 文件");
        }
    }
}