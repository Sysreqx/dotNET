using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTour
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] l = System.IO.File.ReadAllLines(@"C:\Users\SysRq\source\repos\KazTour\KazTour\Resourses\Countries.txt");
            List<string> countries = new List<string>();
            foreach (var i in l)
                countries.Add(i);

            TourStorage tourStrg = new TourStorage();
            foreach (var i in countries)
            {
                string[] tourCountry = System.IO.File.ReadAllLines($@"C:\Users\SysRq\source\repos\KazTour\KazTour\Resourses\Hotels\{i}.txt");
                foreach (var item in tourCountry)
                {
                    Tour t = new Tour($"{item}", new DateTime(2017, 1, 18), 5, 10);
                    tourStrg.AddTour(t);
                }
            }

            tourStrg.ShowAllTours();

            #region test
            //Tour t = new Tour("Italy", new DateTime(2017, 1, 18), 5, 10);
            //int a = t.numberOfSeats;
            //DateTime d = t.date;
            //Console.WriteLine(d.ToString("d"));
            //Console.WriteLine();
            //foreach (var i in countries)
            //{
            //    Console.WriteLine(i);
            //}
            #endregion
            Console.ReadLine();
        }
    }
}
