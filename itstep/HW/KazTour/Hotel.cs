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
        public int numberOfStar { get; set; }

        public Hotel(string name, int numberOfStar)
        {
            this.name = name;
            this.numberOfStar = numberOfStar;
        }
    }
}
