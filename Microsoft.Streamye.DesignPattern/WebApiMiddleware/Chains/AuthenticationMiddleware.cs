using System;

namespace Microsoft.Streamye.DesignPattern.WebApiMiddleware.Chains
{
    public class AuthenticationMiddleware : AbstractMiddleware
    {
        // private AuthorizationMiddleware nextMiddleware;
        // private AbstractMiddleware nextMiddleware;

        public override void HandleHttpRequest(HttpRequest request)
        {
            Console.WriteLine("authentication handle: " + request.requestUrl);

            if (NextMiddleware != null)
            {
                NextMiddleware.HandleHttpRequest(request);
            }
        }
    }
}