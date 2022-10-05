using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Date_Modifier
{
    public class DateModifier
    {
        private DateTime firstDate;
        private DateTime lastDate;
        private double totalDays;

        public DateModifier(DateTime firstDate, DateTime lastDate)
        {
            FirstDate = this.firstDate;
            LastDate = this.lastDate;
            TotalDays = this.totalDays;
        }
        public DateTime FirstDate { get { return firstDate; } set { firstDate = value; } }
        public DateTime LastDate { get { return lastDate; } set { lastDate = value; } }
        public double TotalDays { get { return totalDays; } set { totalDays = value; } }


        public double Calculator()
        {
            return totalDays = (firstDate.Date - LastDate.Date).TotalDays;
        }
    }
}
