﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList :List<string>
    {
        private readonly Random random;

        public RandomList()
        {
            random = new Random();
        }

        public string RandomString()
        {
            int index = random.Next(0, this.Count);

            string str = this[index];
            this.RemoveAt(index);

            return str;
        }
    }
}
