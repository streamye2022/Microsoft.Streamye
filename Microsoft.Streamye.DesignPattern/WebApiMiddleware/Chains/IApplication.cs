using System.Collections.Generic;

namespace Microsoft.Streamye.DesignPattern.WebApiMiddleware.Chains
{
    public class IApplication
    {
        private List<AbstractMiddleware> _middlewares = new List<AbstractMiddleware>();

        public void AddMiddleware(AbstractMiddleware middleware)
        {
            _middlewares.Add(middleware);
        }

        public AbstractMiddleware GetMiddleware()
        {
            //空头
            AbstractMiddleware headerMiddleware = new NullMiddleware();
            // 中间变量
            AbstractMiddleware middlewareMiddle = null;

            // 3、形成中间件链
            foreach (var middleware in _middlewares)
            {
                if (middlewareMiddle == null)
                {
                    headerMiddleware.NextMiddleware = middleware;
                }else
                {
                    middlewareMiddle.NextMiddleware = middleware;
                }
                middlewareMiddle = middleware;
            }

            return headerMiddleware;
        }


    }
}