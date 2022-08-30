using System;

namespace Microsoft.Streamye.DesignPattern.Factory.Shapes
{
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("draw a square");
        }
    }
}