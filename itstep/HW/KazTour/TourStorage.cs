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
                if (flag == true)
                {
                    tourStorage.Add(tour);
                }
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
        public void ShowAllTours()
        {
            foreach (var i in tourStorage)
            {
                Console.WriteLine(i);
            }
        }
    }
}
