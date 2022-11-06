namespace Shapes
{
    using System;

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => this.radius;
            private set => this.radius = value;
        }

        public override double CalculatePerimeter() => Math.PI * (2 * this.Radius);


        public override double CalculateArea() => Math.PI * this.Radius * this.Radius;


        public override string Draw()
        {
            return base.Draw() + " Circle";
        }
    }
}
