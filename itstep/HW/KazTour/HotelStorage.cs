using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTour
{
    class HotelStorage
    {
        public List<Hotel> hotelStorage { get; set; }

        public void AddHotel(Hotel hotel)
        {
            bool flag = true;
            foreach (var item in hotelStorage)
            {
                if (item == hotel)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                hotelStorage.Add(hotel);
            }
        }
        public void DeleteHotel(Hotel hotel)
        {
            int pos = 0;
            bool flag = false;
            foreach (var item in hotelStorage)
            {
                if (item == hotel)
                {
                    flag = true;
                    break;
                }
                ++pos;
            }
            if (flag)
            {
                hotelStorage.RemoveAt(pos);
            }
        }
    }
}
