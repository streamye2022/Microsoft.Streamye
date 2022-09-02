using System.Collections.Generic;
using Microsoft.Streamye.DesignPattern.Chain.Manager;

namespace Microsoft.Streamye.DesignPattern.Chain
{
    public class ProductAudit
    {
        private List<AbstractManager> managers = new List<AbstractManager>();
        
        //add manager
        public void AddManager(AbstractManager manager)
        {
            managers.Add(manager);
        }
        
        // get Manager
        public AbstractManager GetManager()
        {
            //空头
            AbstractManager headerManager = new NullManager();
            // 中间变量
            AbstractManager managerMiddle = null;

            // 3、形成中间件链
            foreach (var manager in managers)
            {
                if (managerMiddle == null)
                {
                    headerManager.NextAbstractManager = manager;
                }else
                {
                    managerMiddle.NextAbstractManager = manager;
                }
                managerMiddle = manager;
            }

            return headerManager;
        }
        
    }
}