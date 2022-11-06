namespace Shapes
{
    using System;

    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get => this.height;
            private set
            {
                this.height = value;
            }

        }

        public double Width
        {
            get =>this.width;
            private set => this.width = value;
        }

       
        public override double CalculatePerimeter() => this.Width + this.Width + this.Height + this.Height;

        public override double CalculateArea() => this.Width * this.Height;

        public override string Draw()
        {
            return base.Draw() + " Rectangle";
        }
    }
}
