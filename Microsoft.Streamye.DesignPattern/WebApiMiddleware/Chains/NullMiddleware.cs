namespace Microsoft.Streamye.DesignPattern.WebApiMiddleware.Chains
{
    public class NullMiddleware : AbstractMiddleware
    {
        public override void HandleHttpRequest(HttpRequest request)
        {
            if (NextMiddleware != null)
            {
                NextMiddleware.HandleHttpRequest(request);
            }
        }
    }
}