using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTour
{
    class Hotel
    {
        public string name { get; set; }
        public int numberOfStars { get; set; }

        public Hotel(string name, int numberOfStars)
        {
            this.name = name;
            this.numberOfStars = numberOfStars;
        }
    }
}
