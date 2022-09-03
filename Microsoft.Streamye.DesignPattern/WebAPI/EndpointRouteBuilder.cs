using System;
using System.Reflection;
using Microsoft.Streamye.DesignPattern.WebAPI.Attributes;

namespace Microsoft.Streamye.DesignPattern.WebAPI
{
    public class EndpointRouteBuilder
    {
        private EndpointDataSources _endpointDataSources = new EndpointDataSources();

        public void MapControllers()
        {
            Assembly assembly = Assembly.Load("Microsoft.Streamye.DesignPattern");

            Type[] types = assembly.GetTypes();

            foreach (var type in types)
            {
                ApiController apiController = type.GetCustomAttribute<ApiController>();
                if (apiController != null)
                {
                    //创建对象
                    object _object = Activator.CreateInstance(type);
                    
                    //获得方法
                    var methodInfos = type.GetMethods();

                    foreach (var methodInfo in methodInfos)
                    {
                        Router router = methodInfo.GetCustomAttribute<Router>();
                        if (router != null)
                        {
                            //拼装endpoint,塞进endpoint map中
                            Endpoint endpoint = new Endpoint();
                            endpoint.methodInfo = methodInfo;
                            endpoint.Controller = _object;
                            endpoint.parameterInfos = methodInfo.GetParameters();

                            // 2、添加到端点集合
                            _endpointDataSources._endpoints.Add(apiController.Path+"/"+router.Path, endpoint);
                        }

                    }
                }
            }
        }

        public EndpointDataSources Build()
        {
            return _endpointDataSources;
        }
    }
}