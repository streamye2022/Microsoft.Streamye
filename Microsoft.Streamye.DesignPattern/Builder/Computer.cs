using Microsoft.Streamye.DesignPattern.Builder.component;

namespace Microsoft.Streamye.DesignPattern.Builder
{
    public class Computer
    {
        private Computer _computer;
        public AbstractCPU Cpu { set; get; }
        
        public AbstractMemory Memory { set; get; }
        
        public AbstractFrame Frame { set; get; }

        public Computer()
        {
            
        }
        
        public Computer(AbstractCPU _cpu, AbstractMemory _memory, AbstractFrame _frame)
        {
            this.Cpu = _cpu;
            this.Memory = _memory;
            this.Frame = _frame;
        }
        
        

    }
}