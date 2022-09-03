using Microsoft.Streamye.DesignPattern.WebApiMiddleware.Chains;

namespace Microsoft.Streamye.DesignPattern.WebApiMiddleware
{
    public class Startup
    {
        public void Configure(IApplicationBuilder builder)
        {
            builder.UseAuthorizationMiddleware();
            
            //use 其他的middleware
            
            
        }
        
    }
}