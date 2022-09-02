namespace Microsoft.Streamye.DesignPattern.Builder
{
    public interface IComputerBuilder
    {
        public IComputerBuilder BuildCPU();
        
        public IComputerBuilder BuildMemory();
        
        public IComputerBuilder BuildFrame();
        
        public Computer Build();
    }
}