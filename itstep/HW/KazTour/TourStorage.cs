using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTour
{
    class TourStorage
    {
        public List<Tour> tourStorage = new List<Tour>();/* { get; set; }*/
        //public int sizeOfTourStorage { get; set; }

        public void AddTour(Tour tour)
        {
            bool flag = true;
            if (tourStorage != null)
            {
                foreach (var item in tourStorage)
                {
                    if (item == tour)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag == true)
            {
                tourStorage.Add(tour);
            }
        }

        public void DeleteTour(Tour tour)
        {
            int pos = 0;
            bool flag = false;
            foreach (var item in tourStorage)
            {
                if (item == tour)
                {
                    flag = true;
                    break;
                }
                ++pos;
            }
            if (flag)
            {
                tourStorage.RemoveAt(pos);
            }
        }

        
        public void DeleteTourByHotelName(ref TourStorage tourStrg, string hotelName)
        {
            for (int i = 0; i < tourStrg.tourStorage.Count; i++)
            {
                if (tourStrg.tourStorage[i].hotel == hotelName)
                {
                    tourStrg.tourStorage.RemoveAt(i);
                    break;
                }
            }
        }


        public void ShowAllTours()
        {
            string s;
            foreach (var i in tourStorage)
            {
                s = "Country: " + i.country;
                s += "\nHotel: " + i.hotel;
                s += "\nDate: " + i.date.ToString("d");
                s += "\nPeople count: " + i.numberOfSeats;
                s += "\nRest days: " + i.restDays;
                s += "\nNumber of Stars: " + i.numberOfStars + "\n";

                Console.WriteLine(s);
            }
        }


        public void ShowAllHotels()
        {
            foreach (var i in tourStorage)
            {
                Console.WriteLine(i.hotel);
                Console.WriteLine(i.price);
                Console.WriteLine("--------------------");
            }
        }


        public void ShowTourByCountry(string c)
        {
            string s;
            foreach (var i in tourStorage)
            {
                if (i.country == c)
                {
                    s = "Country: " + i.country;
                    s += "\nHotel: " + i.hotel;
                    s += "\nDate: " + i.date.ToString("d");
                    s += "\nPeople count: " + i.numberOfSeats;
                    s += "\nRest days: " + i.restDays;
                    s += "\nPrice: " + i.price;
                    s += "\nNumber of Stars: " + i.numberOfStars + "\n";

                    Console.WriteLine(s);
                }
            }
        }


        public void ShowTourByDate(int m, int d)
        {
            string s;
            foreach (var i in tourStorage)
            {
                if (i.date.Day == d && i.date.Month == m)
                {
                    s = "Country: " + i.country;
                    s += "\nHotel: " + i.hotel;
                    s += "\nDate: " + i.date.ToString("d");
                    s += "\nPeople count: " + i.numberOfSeats;
                    s += "\nRest days: " + i.restDays;
                    s += "\nPrice: " + i.price;
                    s += "\nNumber of Stars: " + i.numberOfStars + "\n";

                    Console.WriteLine(s);
                }
            }
        }


        public void ShowTourByNumberOfSeats(int nos)
        {
            string s;
            foreach (var i in tourStorage)
            {
                if (i.numberOfSeats == nos)
                {
                    s = "Country: " + i.country;
                    s += "\nHotel: " + i.hotel;
                    s += "\nDate: " + i.date.ToString("d");
                    s += "\nPeople count: " + i.numberOfSeats;
                    s += "\nRest days: " + i.restDays;
                    s += "\nPrice: " + i.price;
                    s += "\nNumber of Stars: " + i.numberOfStars + "\n";

                    Console.WriteLine(s);
                }
            }
        }


        public void ShowTourByNumberOfSeatsAndDate(int nos, int m, int d)
        {
            string s;
            foreach (var i in tourStorage)
            {
                if (i.date.Day == d && i.date.Month == m && i.numberOfSeats == nos)
                {
                    s = "Country: " + i.country;
                    s += "\nHotel: " + i.hotel;
                    s += "\nDate: " + i.date.ToString("d");
                    s += "\nPeople count: " + i.numberOfSeats;
                    s += "\nRest days: " + i.restDays;
                    s += "\nPrice: " + i.price;
                    s += "\nNumber of Stars: " + i.numberOfStars + "\n";

                    Console.WriteLine(s);
                }
            }
        }


        public void ShowTourByNumberOfSeatsAndCountry(int nos, string c)
        {
            string s;
            foreach (var i in tourStorage)
            {
                if (i.numberOfSeats == nos && i.country == c)
                {
                    s = "Country: " + i.country;
                    s += "\nHotel: " + i.hotel;
                    s += "\nDate: " + i.date.ToString("d");
                    s += "\nPeople count: " + i.numberOfSeats;
                    s += "\nRest days: " + i.restDays;
                    s += "\nPrice: " + i.price;
                    s += "\nNumber of Stars: " + i.numberOfStars + "\n";

                    Console.WriteLine(s);
                }
            }
        }


        public void ShowTourByCountryAndDate(string c, int m, int d)
        {
            string s;
            foreach (var i in tourStorage)
            {
                if (i.date.Day == d && i.date.Month == m && i.country == c)
                {
                    s = "Country: " + i.country;
                    s += "\nHotel: " + i.hotel;
                    s += "\nDate: " + i.date.ToString("d");
                    s += "\nPeople count: " + i.numberOfSeats;
                    s += "\nRest days: " + i.restDays;
                    s += "\nPrice: " + i.price;
                    s += "\nNumber of Stars: " + i.numberOfStars + "\n";

                    Console.WriteLine(s);
                }
            }
        }


        public void ShowTourByCountryAndDateAndNOS(string c, int m, int d, int nos)
        {
            string s;
            foreach (var i in tourStorage)
            {
                if (i.date.Day == d && i.date.Month == m && i.country == c && i.numberOfSeats == nos)
                {
                    s = "Country: " + i.country;
                    s += "\nHotel: " + i.hotel;
                    s += "\nDate: " + i.date.ToString("d");
                    s += "\nPeople count: " + i.numberOfSeats;
                    s += "\nRest days: " + i.restDays;
                    s += "\nPrice: " + i.price;
                    s += "\nNumber of Stars: " + i.numberOfStars + "\n";

                    Console.WriteLine(s);
                }
            }
        }
    }
}
