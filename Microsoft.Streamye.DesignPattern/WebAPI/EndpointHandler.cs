using System;

namespace Microsoft.Streamye.DesignPattern.WebAPI
{
    public class EndpointHandler
    {
        /// <summary>
        /// 处理 endpoint
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public Object HandlerEndpoint(Endpoint endpoint,object[] args)
        {
            Object result = endpoint.methodInfo.Invoke(endpoint.Controller, args);
            
            //格式化数据输出: 根据result.dataType
            return result;
        }
    }
}