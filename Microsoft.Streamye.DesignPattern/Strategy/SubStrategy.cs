namespace Microsoft.Streamye.DesignPattern.Strategy
{
    public class SubStrategy: IStrategy
    {
        public int doMath(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}