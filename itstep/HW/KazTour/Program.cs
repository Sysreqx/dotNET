using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTour
{
    class Program
    {
        static void FillTours(ref string[] countries, ref TourStorage tourStrg)
        {
            // Random
            Random r = new Random();
            // Current year, month, day
            DateTime d = DateTime.Today;
            int cY = d.Year;
            int cM = d.Month;
            int cD = d.Day;
            // Random

            foreach (var i in countries)
            {
                string[] tourCountry = System.IO.File.ReadAllLines($@"C:\Users\SysRq\source\repos\KazTour\KazTour\Resourses\Hotels\{i}.txt", Encoding.UTF8);
                foreach (var item in tourCountry)
                {
                    // Country, hotel, year, month, day, number of people, number of rest days
                    Tour t = new Tour($"{i}", $"{item}", new DateTime(cY, r.Next(cM, 13), r.Next(cD, 31)), r.Next(2, 5), r.Next(3, 22), r.Next(3, 6));
                    tourStrg.AddTour(t);
                }
            }
        }
        static void HintMenu(ref string[] countries)
        {
            int cnt = 0;
            Console.WriteLine("\t\t\t\t\tList of available countries: \n");
            foreach (var i in countries)
            {
                Console.Write("{0, -25}", i);
                ++cnt;
                if (cnt == 5)
                {
                    Console.WriteLine();
                    cnt = 0;
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tNumber of seats: 2 - 4");
            Console.WriteLine("\t\t\t\t\tDays of the rest: 3 - 21");
        }


        static void BuyTour(ref TourStorage tourStrg, ref TourStorage userTours, string hotelName, ref int check)
        {
            // ToList() = magic stuff, without it doesn't work
            // https://stackoverflow.com/questions/604831/collection-was-modified-enumeration-operation-may-not-execute
            foreach (var i in tourStrg.tourStorage.ToList())
            {
                string s;
                if (i.hotel == hotelName)
                {
                    s = "Country: " + i.country;
                    s += "\nHotel: " + i.hotel;
                    s += "\nDate: " + i.date.ToString("d");
                    s += "\nPeople count: " + i.numberOfSeats;
                    s += "\nRest days: " + i.restDays;
                    s += "\nPrice: " + i.price;
                    s += "\nNumber of Stars: " + i.numberOfStars + "\n";
                    check += i.price;
                    tourStrg.DeleteTourByHotelName(ref tourStrg, hotelName);
                    userTours.AddTour(i);

                    Console.WriteLine(s);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] countries = System.IO.File.ReadAllLines(@"C:\Users\SysRq\source\repos\KazTour\KazTour\Resourses\Countries.txt", Encoding.UTF8);
            TourStorage tourStrg = new TourStorage();
            FillTours(ref countries, ref tourStrg);

            bool f = true;
            int trigger = 8;
            // Total money spend
            int totalCheck = 0;
            // Bought tours
            TourStorage userTours = new TourStorage();
            while (f)
            {
                HintMenu(ref countries);

                Console.WriteLine("0. Exit");
                Console.WriteLine("9. Return to home screen");
                Console.WriteLine("1. Search by country");
                Console.WriteLine("2. Search by date");
                Console.WriteLine("3. Search by number of people");
                Console.WriteLine("4. Search by number of people and date");
                Console.WriteLine("5. Search by number of people and country");
                Console.WriteLine("6. Search by country and date");
                Console.WriteLine("7. Search by country, date and number of people");
                //trigger = int.Parse(Console.ReadLine()) % 10;

                // Cheking to correct input
                Console.WriteLine("Enter Number");
                while (trigger > 9 || trigger < 0 || trigger == 8)
                {
                    while (!int.TryParse(Console.ReadLine(), out trigger))
                    {
                        Console.WriteLine("Input Error! Enter number from menu");
                    }
                }
                // Hard Crutch.

                // Search by country.
                if (1 == trigger)
                {
                    // Check for correctly Country name
                    string s = "";
                    bool fl = true;
                    while (fl)
                    {
                        Console.WriteLine("Enter country from list");
                        s = Console.ReadLine();
                        foreach (var i in countries)
                            if (s == i)
                                fl = false;
                    }

                    tourStrg.ShowTourByCountry(s);
                    Console.WriteLine("Press any key, to return to the home screen");
                    //
                    foreach (var i in countries)
                        if (i == s)
                        {
                            Console.WriteLine("Enter hotel name, to buy tour");
                            s = Console.ReadLine();
                        }
                    //
                    Console.Clear();
                    Console.WriteLine("You are having tours");
                    userTours.ShowAllHotels();
                    Console.WriteLine("You bought tour: ");
                    BuyTour(ref tourStrg, ref userTours, s, ref totalCheck);
                    Console.WriteLine($"You spend {totalCheck} $");
                    trigger = 8;
                    Console.WriteLine("Press any key, to return to the home screen");
                }


                // Search by date.
                if (trigger == 2)
                {
                    DateTime x = DateTime.Today;
                    Random rnd = new Random();
                    //

                    int m = 0, d = 0;
                    Console.WriteLine($"Enter month ({x.Month}-12)");
                    while (m == 0 || m > 12 || m < x.Month)
                        while (!int.TryParse(Console.ReadLine(), out m))
                            Console.WriteLine($"Input Error! Enter month ({x.Month}-12)");

                    Console.WriteLine($"Enter Day ({x.Day}-30)");
                    while (d == 0 || d > 30 || d < x.Day)
                        while (!int.TryParse(Console.ReadLine(), out d))
                            Console.WriteLine($"Input Error! Enter day ({x.Day}-30)");

                    // if input incorrect
                    //if (m < x.Month)
                    //    m = rnd.Next(x.Month, 13);
                    //if (d < x.Day)
                    //    d = rnd.Next(x.Day, 31);
                    //m %= 13;
                    //d %= 31;
                    //

                    tourStrg.ShowTourByDate(m, d);
                    string s = "";
                    Console.WriteLine("Press any key, to return to the home screen");
                    //
                    foreach (var i in tourStrg.tourStorage)
                        if (i.date.Day == d && i.date.Month == m)
                        {
                            Console.WriteLine("Enter hotel name, to buy tour");
                            s = Console.ReadLine();
                            break;
                        }
                    //
                    Console.Clear();
                    Console.WriteLine("You are having tours");
                    userTours.ShowAllHotels();
                    if (s != "")
                    {
                        Console.WriteLine("You bought tour: ");
                        BuyTour(ref tourStrg, ref userTours, s, ref totalCheck);
                    }

                    Console.WriteLine($"You spend {totalCheck} $");
                    trigger = 8;
                    Console.WriteLine("Press any key, to return to the home screen");
                }


                // Search by number of people.
                if (trigger == 3)
                {
                    int p = 0;
                    Console.WriteLine("Enter people count (2-4)");
                    while (p > 4 || p < 2 || p == 0)
                    {
                        while (!int.TryParse(Console.ReadLine(), out p))
                            Console.WriteLine($"Input Error! Enter people count (2-4)");
                    }

                    tourStrg.ShowTourByNumberOfSeats(p);
                    string s = "";
                    Console.WriteLine("Press any key, to return to the home screen");
                    // Compare input number with each tour
                    foreach (var i in tourStrg.tourStorage)
                        if (i.numberOfSeats == p)
                        {
                            Console.WriteLine("Enter hotel name, to buy tour");
                            s = Console.ReadLine();
                            break;
                        }
                    //
                    Console.Clear();
                    Console.WriteLine("You are having tours");
                    userTours.ShowAllHotels();
                    if (s != "")
                    {
                        Console.WriteLine("You bought tour: ");
                        BuyTour(ref tourStrg, ref userTours, s, ref totalCheck);
                    }

                    Console.WriteLine($"You spend {totalCheck} $");
                    trigger = 8;
                    Console.WriteLine("Press any key, to return to the home screen");
                }


                // Search by number of people and date.
                if (trigger == 4)
                {
                    DateTime x = DateTime.Today;
                    Random rnd = new Random();
                    // Month Day
                    Console.WriteLine($"Enter month ({x.Month}-12)");
                    int m = 0, d = 0;
                    while (m == 0 || m > 12 || m < x.Month)
                        while (!int.TryParse(Console.ReadLine(), out m))
                            Console.WriteLine($"Input Error! Enter month ({x.Month}-12)");

                    Console.WriteLine($"Enter Day ({x.Day}-30)");
                    while (d == 0 || d > 30 || d < x.Day)
                        while (!int.TryParse(Console.ReadLine(), out d))
                            Console.WriteLine($"Input Error! Enter day ({x.Day}-30)");

                    // Number of Seats
                    Console.WriteLine("Enter people count (2-4)");
                    int p = 0;
                    while (p > 4 || p < 2 || p == 0)
                    {
                        while (!int.TryParse(Console.ReadLine(), out p))
                            Console.WriteLine($"Input Error! Enter people count (2-4)");
                    }

                    tourStrg.ShowTourByNumberOfSeatsAndDate(p, m, d);
                    string s = "";
                    Console.WriteLine("Press any key, to return to the home screen");
                    // Compare input numbers with each tour
                    foreach (var i in tourStrg.tourStorage)
                        if (i.numberOfSeats == p && i.date.Day == d && i.date.Month == m)
                        {
                            Console.WriteLine("Enter hotel name, to buy tour");
                            s = Console.ReadLine();
                            break;
                        }
                    //
                    Console.Clear();
                    Console.WriteLine("You are having tours");
                    userTours.ShowAllHotels();
                    if (s != "")
                    {
                        Console.WriteLine("You bought tour: ");
                        BuyTour(ref tourStrg, ref userTours, s, ref totalCheck);
                    }

                    Console.WriteLine($"You spend {totalCheck} $");
                    trigger = 8;
                    Console.WriteLine("Press any key, to return to the home screen");
                }


                // Search by number of people and country.
                if (trigger == 5)
                {
                    // Number of Seats
                    Console.WriteLine("Enter people count (2-4)");
                    int p = 0;
                    while (p > 4 || p < 2 || p == 0)
                    {
                        while (!int.TryParse(Console.ReadLine(), out p))
                            Console.WriteLine($"Input Error! Enter people count (2-4)");
                    }

                    // Check for correctly Country name
                    string s = "";
                    bool fl = true;
                    while (fl)
                    {
                        Console.WriteLine("Enter country from list");
                        s = Console.ReadLine();
                        foreach (var i in countries)
                            if (s == i)
                                fl = false;
                    }

                    tourStrg.ShowTourByNumberOfSeatsAndCountry(p, s);
                    Console.WriteLine("Press any key, to return to the home screen");

                    // Compare input numbers with each tour
                    foreach (var i in tourStrg.tourStorage)
                        if (i.numberOfSeats == p && i.country == s)
                        {
                            Console.WriteLine("Enter hotel name, to buy tour");
                            s = Console.ReadLine();
                            break;
                        }
                    //
                    Console.Clear();
                    Console.WriteLine("You are having tours");
                    userTours.ShowAllHotels();
                    if (s != "")
                    {
                        Console.WriteLine("You bought tour: ");
                        BuyTour(ref tourStrg, ref userTours, s, ref totalCheck);
                    }

                    Console.WriteLine($"You spend {totalCheck} $");
                    trigger = 8;
                    Console.WriteLine("Press any key, to return to the home screen");
                }


                // Search by country and date.
                if (trigger == 6)
                {
                    DateTime x = DateTime.Today;
                    Random rnd = new Random();
                    //

                    // Check for correctly Month and day.
                    int m = 0, d = 0;
                    Console.WriteLine($"Enter month ({x.Month}-12)");
                    while (m == 0 || m > 12 || m < x.Month)
                        while (!int.TryParse(Console.ReadLine(), out m))
                            Console.WriteLine($"Input Error! Enter month ({x.Month}-12)");

                    Console.WriteLine($"Enter Day ({x.Day}-30)");
                    while (d == 0 || d > 30 || d < x.Day)
                        while (!int.TryParse(Console.ReadLine(), out d))
                            Console.WriteLine($"Input Error! Enter day ({x.Day}-30)");


                    // Check for correctly Country name.
                    string s = "";
                    bool fl = true;
                    while (fl)
                    {
                        Console.WriteLine("Enter country from list");
                        s = Console.ReadLine();
                        foreach (var i in countries)
                            if (s == i)
                                fl = false;
                    }

                    tourStrg.ShowTourByCountryAndDate(s, m, d);
                    Console.WriteLine("Press any key, to return to the home screen");

                    // Compare input numbers with each tour
                    foreach (var i in tourStrg.tourStorage)
                        if (i.country == s && i.date.Day == d && i.date.Month == m)
                        {
                            Console.WriteLine("Enter hotel name, to buy tour");
                            s = Console.ReadLine();
                            break;
                        }
                    //
                    Console.Clear();
                    Console.WriteLine("You are having tours");
                    userTours.ShowAllHotels();
                    if (s != "")
                    {
                        Console.WriteLine("You bought tour: ");
                        BuyTour(ref tourStrg, ref userTours, s, ref totalCheck);
                    }

                    Console.WriteLine($"You spend {totalCheck} $");
                    trigger = 8;
                    Console.WriteLine("Press any key, to return to the home screen");
                }


                // Search by country, date and number of people.
                if (trigger == 7)
                {
                    DateTime x = DateTime.Today;
                    Random rnd = new Random();
                    //

                    // Check for correctly Month and day.
                    int m = 0, d = 0;
                    Console.WriteLine($"Enter month ({x.Month}-12)");
                    while (m == 0 || m > 12 || m < x.Month)
                        while (!int.TryParse(Console.ReadLine(), out m))
                            Console.WriteLine($"Input Error! Enter month ({x.Month}-12)");

                    Console.WriteLine($"Enter Day ({x.Day}-30)");
                    while (d == 0 || d > 30 || d < x.Day)
                        while (!int.TryParse(Console.ReadLine(), out d))
                            Console.WriteLine($"Input Error! Enter day ({x.Day}-30)");


                    // Number of Seats
                    Console.WriteLine("Enter people count (2-4)");
                    int p = 0;
                    while (p > 4 || p < 2 || p == 0)
                    {
                        while (!int.TryParse(Console.ReadLine(), out p))
                            Console.WriteLine($"Input Error! Enter people count (2-4)");
                    }

                    // Check for correctly Country name.
                    string s = "";
                    bool fl = true;
                    while (fl)
                    {
                        Console.WriteLine("Enter country from list");
                        s = Console.ReadLine();
                        foreach (var i in countries)
                            if (s == i)
                                fl = false;
                    }

                    tourStrg.ShowTourByCountryAndDateAndNOS(s, m, d, p);
                    Console.WriteLine("Press any key, to return to the home screen");

                    // Compare input numbers with each tour
                    foreach (var i in tourStrg.tourStorage)
                        if (i.country == s && i.date.Day == d && i.date.Month == m && i.numberOfSeats == p)
                        {
                            Console.WriteLine("Enter hotel name, to buy tour");
                            s = Console.ReadLine();
                            break;
                        }
                    //
                    Console.Clear();
                    Console.WriteLine("You are having tours");
                    userTours.ShowAllHotels();
                    if (s != "")
                    {
                        Console.WriteLine("You bought tour: ");
                        BuyTour(ref tourStrg, ref userTours, s, ref totalCheck);
                    }

                    Console.WriteLine($"You spend {totalCheck} $");
                    trigger = 8;
                    Console.WriteLine("Press any key, to return to the home screen");
                }


                // Return to home screen ORR...
                if (9 == trigger)
                {
                    trigger = 8;
                    continue;
                }


                // Exit.
                if (0 == trigger)
                {
                    f = false;
                }

                Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine("You are having tours");
            userTours.ShowAllHotels();
            Console.WriteLine($"You spend {totalCheck} $");

            Console.ReadLine();
        }
    }
}
