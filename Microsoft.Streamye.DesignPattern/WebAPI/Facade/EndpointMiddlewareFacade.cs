namespace Microsoft.Streamye.DesignPattern.WebAPI.Facade
{
    public class EndpointMiddlewareFacade
    {
        EndpointRouteBuilder endpointRouteBuilder ;
        EndpointRoute endpointRoute;
        EndpointHandler endpointHandler;
        
        public EndpointMiddlewareFacade()
        {
            this.endpointRouteBuilder = new EndpointRouteBuilder();
            this.endpointRoute = new EndpointRoute();
            this.endpointHandler = new EndpointHandler();
        }


        public void Invoke(HttpContext httpContext)
        {
            //得到endpoints 集合
            endpointRouteBuilder.MapControllers();
            
            //得到endpointRoute
            endpointRoute.endpointDataSources = endpointRouteBuilder.Build();
            
            httpContext.requestUrl = "canary/checkvm";
            Endpoint endpoint = endpointRoute.Match(httpContext);

            // 3、执行端点
            object result1 = endpointHandler.HandlerEndpoint(endpoint, new object[] { });
            
            // 4、把结果响应到客户端 => 优化一下：工厂模式
            // if (endpoint.dataType.Equals("json"))
            // {
            //     AbstractView jSONView = new JSONView();
            //     jSONView.Render(result, httpContext);
            // }
            // else if (endpoint.dataType.Equals("xml"))
            // {
            //     AbstractView xMLView = new XMLView();
            //     xMLView.Render(result, httpContext);
            // }
            
        }

    }
}