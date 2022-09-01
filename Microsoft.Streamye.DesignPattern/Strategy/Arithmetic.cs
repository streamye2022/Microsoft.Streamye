namespace Microsoft.Streamye.DesignPattern.Strategy
{
    public class Arithmetic
    {
        //IStrategy 通过依赖注入的方式
        private IStrategy strategy;
        public Arithmetic(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int doMath(int num1, int num2){
        // public int doMath(int num1, int num2,IStrategy strategy){
        // public int doMath(int num1, int num2,string mathType){
            // if (mathType == "add")
            // {
            //     return num1 + num2;
            // }else if (mathType == "sub")
            // {
            //     return num1 - num2;
            // }
            // 问题：1.如果新增mul 和div，开闭原则不符合 => 策略模式
            
            // 问题：2.和Factory模式区别： 关注过程还是关注对象
            
            return strategy.doMath(num1, num2);
            
            // return 0;
        }
    }
}