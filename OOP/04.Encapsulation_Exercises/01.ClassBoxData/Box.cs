
using System.Text;

namespace _01.ClassBoxData
{
    using System;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }


        public double Length
        {
            get => this.length;
            private set
            {
                if (IsValueInvalid(value))
                    throw new ArgumentException(string.Format(ExceptionMessage.NumberIsBelowZero, nameof(this.Length)));
                this.length = value;
            }

        }

        public double Width
        {
            get => this.width;
            private set
            {
                if (IsValueInvalid(value))
                    throw new ArgumentException(string.Format(ExceptionMessage.NumberIsBelowZero, nameof(this.Width)));
                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (IsValueInvalid(value))
                    throw new ArgumentException(string.Format(ExceptionMessage.NumberIsBelowZero, nameof(this.Height)));
                this.height = value;
            }

        }


        private double SurfaceArea()
            => (2 * this.Length * this.Width) + LateralSurfaceArea();

        private double LateralSurfaceArea()
            => (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

        private double Volume()
            => this.Length * this.Width * this.Height;

        private static bool IsValueInvalid(double value)
            => value <= 0;


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {this.Volume():F2}");

            return sb.ToString().Trim();
        }
    }
}
