namespace Microsoft.Streamye.DesignPattern.Iterator.Impl
{
    public class List : IIterable
    {
        private static string[] names = { "zhangsan","lisi","wangwu"};

        public string[] GetNames()
        {
            return names;
        }
        
        
        private class ListIterator : IIterator
        {
            private int index;
            public bool HasNext()
            {
                if (index < names.Length)
                {
                    return true;
                }

                return false;
            }

            public string Next()
            {
                if (this.HasNext())
                {
                    return names[index++];
                }
                return null;
            }
        }

        public IIterator GetIterator()
        {
            return new ListIterator();
        }
    }
}