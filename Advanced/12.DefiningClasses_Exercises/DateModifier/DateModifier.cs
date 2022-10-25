using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    internal class DateModifier
    {
        private string firstDate;
        private string secondDate;

        public string FirstDate
        {
            get { return this.firstDate;}
            set { this.firstDate = value; }
        }

        public string SecondDate
        {
            get { return this.secondDate;}
            set { this.secondDate = value; }
        }

        public int DayDifferences(string firstDate, string secondDate)
        {
            var startDate = DateTime.Parse(firstDate);
            var lastDate = DateTime.Parse(secondDate);

            TimeSpan dayDiff = lastDate - startDate;

            return Math.Abs(dayDiff.Days);
        }
    }
}
