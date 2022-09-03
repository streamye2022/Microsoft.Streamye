using System;

namespace Microsoft.Streamye.DesignPattern.WebApiMiddleware.Chains
{
    public class AuthorizationMiddleware : AbstractMiddleware
    {
        public override void HandleHttpRequest(HttpRequest request)
        {
            Console.WriteLine("authorization handle: " + request.requestUrl);
            if (NextMiddleware != null)
            {
                NextMiddleware.HandleHttpRequest(request);
            }
        }
    }
}