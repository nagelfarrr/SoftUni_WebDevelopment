using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace GenericBox
{
    public class Box<T> where T : IComparable
    {

        public Box()
        {

            this.List = new List<T>();
        }

        public List<T> List { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var list in List)
            {
                sb.AppendLine($"{typeof(T)}: {list}");

            }

            return sb.ToString().TrimEnd();
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            (this.List[firstIndex], this.List[secondIndex]) = (this.List[secondIndex], this.List[firstIndex]);
        }

        public int CompareCount(T elementToCompare)
        {
            int count = 0;

            foreach (var comparable in List)
            {
                if (comparable.CompareTo(elementToCompare) > 0)
                    count++;
            }

            return count;
        }
    }
}
