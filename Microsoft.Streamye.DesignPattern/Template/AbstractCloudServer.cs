namespace Microsoft.Streamye.DesignPattern.Template
{
    public abstract class AbstractCloudServer :ICloudServer
    {
        public void SaveLog()
        {
            //四步算法都相同，规范规范规范
            OpenFile();
            Connection();
            Serialize();
            Transport();
        }

        protected abstract void OpenFile();
        protected abstract void Connection();

        protected abstract void Serialize();

        protected abstract void Transport();
    }
}