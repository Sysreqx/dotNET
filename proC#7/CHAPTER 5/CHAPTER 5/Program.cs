using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The Role of the Default Constructor.

namespace CHAPTER_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with class Types *****\n");
            // Make a Motorcycle.
            Motorcycle c = new Motorcycle(5);
            c.SetDriverName("Tiny");
            MakeSomeBikes();
            Console.ReadLine();
        }

        static void MakeSomeBikes()
        {
            // driverName = "", driverIntensity = 0
            Motorcycle m1 = new Motorcycle();
            Console.WriteLine("Name= {0}, Intensity= {1}",
            m1.driverName, m1.driverIntensity);
            // driverName = "Tiny", driverIntensity = 0
            Motorcycle m2 = new Motorcycle(name: "Tiny");
            Console.WriteLine("Name= {0}, Intensity= {1}",
            m2.driverName, m2.driverIntensity);
            // driverName = "", driverIntensity = 7
            Motorcycle m3 = new Motorcycle(7);
            Console.WriteLine("Name= {0}, Intensity= {1}",
            m3.driverName, m3.driverIntensity);
        }
    }
}
