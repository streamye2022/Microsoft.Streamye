using System;

namespace Microsoft.Streamye.DesignPattern.Factory.Shapes
{
    public class Rectangle: IShape
    {
        public void Draw()
        {
            Console.WriteLine("draw a Rectangle");
        }
    }
}