using System;

namespace Microsoft.Streamye.DesignPattern.Singleton
{
    public class DoubleCheckSingleton
    {
        private volatile static DoubleCheckSingleton instance = null;
        private static readonly Object lock1 = new object();
        
        public static DoubleCheckSingleton Singleton
        {
            get
            {
                if (instance == null)
                {
                    lock (lock1)
                    {
                        if (instance == null)
                        {
                            instance = new DoubleCheckSingleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
}