using System.Collections.Generic;

namespace Microsoft.Streamye.DesignPattern.WebAPI
{
    /// <summary>
    /// 将所有的endpoints 都存起来
    /// </summary>
    public class EndpointDataSources
    {
        public IDictionary<string, Endpoint> _endpoints { set; get; } = new Dictionary<string, Endpoint>();
    }
}