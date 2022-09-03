namespace Microsoft.Streamye.DesignPattern.WebAPI
{
    public class EndpointRoute
    {
        public EndpointDataSources endpointDataSources { get; set; } = null;    

        public Endpoint Match(HttpContext httpContext) {

            // 1、从requestPath 获取uri = Product/Get
            return endpointDataSources._endpoints[httpContext.requestUrl];
        }
    }
}