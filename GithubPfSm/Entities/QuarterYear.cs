using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubPfSm.Entities
{
    public class QuarterYear
    {
        public int Quarter { get; set; }

        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Year}-Q{Quarter}";
        }



        public QuarterYear Next()
        {
            Quarter++;
            if (Quarter >= 5)
            {
                Quarter = 1;
                Year++;
            }
            return new QuarterYear()
            {
                Quarter = Quarter,
                Year = Year

            };
        }

        public static bool operator ==(QuarterYear a, QuarterYear b)
        {
            return a.Quarter == b.Quarter && a.Year == b.Year;
        }

        public static bool operator !=(QuarterYear a, QuarterYear b)
        {
            return a.Quarter != b.Quarter || a.Year != b.Year;
        }

      
        public static QuarterYear GetQuarter(DateTime date)
        {
            return new QuarterYear()
            {
                Year = date.Year,
                Quarter = (date.Month + 2) / 3
            };
        }
    }
}
