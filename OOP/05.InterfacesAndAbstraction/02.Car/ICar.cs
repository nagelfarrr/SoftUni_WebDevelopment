using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }

        void Start();
        void Stop();
    }
}
