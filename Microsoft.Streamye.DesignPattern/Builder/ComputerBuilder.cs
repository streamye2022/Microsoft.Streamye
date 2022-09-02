using Microsoft.Streamye.DesignPattern.Builder.component.Impl;

namespace Microsoft.Streamye.DesignPattern.Builder
{
    public class ComputerBuilder : IComputerBuilder
    {
        private Computer computer = new Computer();
        
        public IComputerBuilder BuildCPU()
        {
            computer.Cpu = new MSCPU();
            return this;
        }

        public IComputerBuilder BuildMemory()
        {
            computer.Memory = new MSMemory();
            return this;
        }

        public IComputerBuilder BuildFrame()
        {
            computer.Frame = new MSFrame();
            return this;
        }

        public Computer Build()
        {
            return computer;
        }
    }
}