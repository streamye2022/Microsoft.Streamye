namespace Microsoft.Streamye.DesignPattern.WebApiMiddleware.Chains
{
    public abstract class AbstractMiddleware
    {
        public AbstractMiddleware NextMiddleware;

        public abstract void HandleHttpRequest(HttpRequest request);
    }
}