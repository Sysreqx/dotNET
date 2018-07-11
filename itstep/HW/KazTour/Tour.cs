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
        public string hotel { get; set; }
        public DateTime date { get; set; }
        public int numberOfSeats { get; set; }
        public int restDays { get; set; }
        public int numberOfStars { get; set; }
        public int price { get; set; }


        public Tour(string country, string hotel, DateTime date, int numberOfSeats, int restDays, int numberOfStars)
        {
            Random r = new Random();
            this.country = country;
            this.hotel = hotel;
            this.date = date;
            this.numberOfSeats = numberOfSeats;
            this.restDays = restDays;
            this.numberOfStars = numberOfStars;
            price = r.Next(1000, 10001);
            price *= numberOfSeats;
        }
    }
}
