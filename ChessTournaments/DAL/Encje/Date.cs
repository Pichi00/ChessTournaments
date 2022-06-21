using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.DAL.Encje
{
    public class Date
    {
        int Day { get; set; }
        int Month { get; set; }
        int Year { get; set; }
        public Date(DateTime dateTime)
        {
            Day = dateTime.Day;
            Month = dateTime.Month;
            Year = dateTime.Year;
        }

        public override string ToString()
        {
            //return $"{Day}.{Month}.{Year}";
            return $"{Year}-{Month}-{Day}";
        }

    }
}
