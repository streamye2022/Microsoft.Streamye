namespace Microsoft.Streamye.DesignPattern.WebApiMiddleware
{
    public class HttpContext
    {
        public HttpRequest request { set; get; }
        public HttpResponse response { set; get; }
    }
}