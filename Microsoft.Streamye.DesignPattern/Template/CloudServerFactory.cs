using Microsoft.Streamye.DesignPattern.Template.Impl;

namespace Microsoft.Streamye.DesignPattern.Template
{
    public class CloudServerFactory
    {
        //继续改进一下，map和配置文件中读
        public static ICloudServer GetCloudServer(string cloudServerType)
        {
            if (cloudServerType == null)
            {
                return null;
            }
            if (cloudServerType.Equals("kusto"))
            {
                return new KustoCloudServer();
            }
            else if (cloudServerType.Equals("es"))
            {
                return new ESCloudServer();
            }
            return null;
        }
    }
}