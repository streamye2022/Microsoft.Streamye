using System;

namespace Microsoft.Streamye.DesignPattern.Factory.Shapes
{
    public class Circle: IShape
    {
        public void Draw()
        {
            Console.WriteLine("draw a circle");
        }
    }
}