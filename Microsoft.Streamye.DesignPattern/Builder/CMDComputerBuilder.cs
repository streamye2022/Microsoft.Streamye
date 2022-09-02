using Microsoft.Streamye.DesignPattern.Builder.component.Impl;
using Microsoft.Streamye.DesignPattern.Builder.component.Impl.CMD;

namespace Microsoft.Streamye.DesignPattern.Builder
{
    public class CMDComputerBuilder:IComputerBuilder
    {
        private Computer computer = new Computer();
        public IComputerBuilder BuildCPU()
        {
            computer.Cpu = new CMDCPU();
            return this;
        }

        public IComputerBuilder BuildMemory()
        {
            computer.Memory = new CMDMemory();
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