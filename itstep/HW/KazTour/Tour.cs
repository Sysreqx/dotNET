using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTour
{
    class Tour
    {
        public string country { get; set; }
        public DateTime date { get; set; }
        public int numberOfSeats { get; set; }
        public int restDays { get; set; }

        public Tour(string country, DateTime date, int numberOfSeats, int restDays)
        {
            this.country = country;
            this.date = date;
            this.numberOfSeats = numberOfSeats;
            this.restDays = restDays;
        }
    }
}
