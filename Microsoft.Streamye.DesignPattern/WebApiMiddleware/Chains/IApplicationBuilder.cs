namespace Microsoft.Streamye.DesignPattern.WebApiMiddleware.Chains
{
    public class IApplicationBuilder
    {
        private IApplication application = new IApplication();

        public void UseAuthorizationMiddleware()
        {
            AuthorizationMiddleware authorization = new AuthorizationMiddleware();
            application.AddMiddleware(authorization);
        }

        public IApplication Build()
        {
            return application;
        }
    }
}