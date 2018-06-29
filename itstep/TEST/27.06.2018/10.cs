using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 10
namespace Test
{
    class Program
    {
        #region names
        static Random r = new Random();
        static string RandomName()
        {
            string s;
            int i = r.Next(1, 110);
            if (i == 1)
                s = "Aaron";
            else if (i == 2)
                s = "Adam";
            else if (i == 3)
                s = "Adrien";
            else if (i == 4)
                s = "Alex";
            else if (i == 5)
                s = "Alexander";
            else if (i == 6)
                s = "Alexandre";
            else if (i == 7)
                s = "Alexis";
            else if (i == 8)
                s = "Ali";
            else if (i == 9)
                s = "Andrew";
            else if (i == 10)
                s = "Anthony";
            else if (i == 11)
                s = "Antoine";
            else if (i == 12)
                s = "Arthur";
            else if (i == 13)
                s = "Austin";
            else if (i == 14)
                s = "AXEL";
            else if (i == 15)
                s = "BEN";
            else if (i == 16)
                s = "Benjamin";
            else if (i == 17)
                s = "Bhagavan";
            else if (i == 18)
                s = "Brahma";
            else if (i == 19)
                s = "Brahman";
            else if (i == 20)
                s = "Brandon";
            else if (i == 21)
                s = "Brian";
            else if (i == 22)
                s = "Charles";
            else if (i == 23)
                s = "Chris";
            else if (i == 24)
                s = "Christian";
            else if (i == 25)
                s = "Christopher";
            else if (i == 26)
                s = "Clement";
            else if (i == 27)
                s = "Daniel";
            else if (i == 28)
                s = "David";
            else if (i == 29)
                s = "Dylan";
            else if (i == 30)
                s = "Emmanuel";
            else if (i == 31)
                s = "Eric";
            else if (i == 32)
                s = "Ethan";
            else if (i == 33)
                s = "Florian";
            else if (i == 34)
                s = "Gabriel";
            else if (i == 35)
                s = "GaneshaThomas";
            else if (i == 36)
                s = "GeorGe";
            else if (i == 37)
                s = "Guillaume";
            else if (i == 38)
                s = "Henry";
            else if (i == 39)
                s = "Hugo";
            else if (i == 40)
                s = "Ibrahim";
            else if (i == 41)
                s = "Isaac";
            else if (i == 42)
                s = "Ishvara";
            else if (i == 43)
                s = "Jack";
            else if (i == 44)
                s = "Jacob";
            else if (i == 45)
                s = "JAKE";
            else if (i == 46)
                s = "James";
            else if (i == 47)
                s = "Jason";
            else if (i == 48)
                s = "Jean";
            else if (i == 49)
                s = "Jeremy";
            else if (i == 50)
                s = "JOE";
            else if (i == 51)
                s = "John";
            else if (i == 52)
                s = "Jonathan";
            else if (i == 53)
                s = "Jordan";
            else if (i == 54)
                s = "Joseph";
            else if (i == 55)
                s = "Josh";
            else if (i == 56)
                s = "Joshua";
            else if (i == 57)
                s = "Julien";
            else if (i == 58)
                s = "Justin";
            else if (i == 59)
                s = "Kevin";
            else if (i == 60)
                s = "Kim";
            else if (i == 61)
                s = "Krishna";
            else if (i == 62)
                s = "Kyle";
            else if (i == 63)
                s = "Lee";
            else if (i == 64)
                s = "Leo";
            else if (i == 65)
                s = "Liam";
            else if (i == 66)
                s = "Louis";
            else if (i == 67)
                s = "Lucas";
            else if (i == 68)
                s = "Luke";
            else if (i == 69)
                s = "Mark";
            else if (i == 70)
                s = "Martin";
            else if (i == 71)
                s = "Mathieu";
            else if (i == 72)
                s = "Matt";
            else if (i == 73)
                s = "Matthew";
            else if (i == 74)
                s = "Max";
            else if (i == 75)
                s = "Maxime";
            else if (i == 76)
                s = "Michael";
            else if (i == 77)
                s = "Mike";
            else if (i == 78)
                s = "Mohamed";
            else if (i == 79)
                s = "Nathan";
            else if (i == 80)
                s = "Nick";
            else if (i == 81)
                s = "Nicolas";
            else if (i == 82)
                s = "Noah";
            else if (i == 83)
                s = "Park";
            else if (i == 84)
                s = "Patrick";
            else if (i == 85)
                s = "Paul";
            else if (i == 86)
                s = "Peter";
            else if (i == 87)
                s = "Pierre";
            else if (i == 88)
                s = "Prabhu";
            else if (i == 89)
                s = "Quentin";
            else if (i == 90)
                s = "Raphael";
            else if (i == 91)
                s = "Richard";
            else if (i == 92)
                s = "Robert";
            else if (i == 93)
                s = "Romain";
            else if (i == 94)
                s = "RYAN";
            else if (i == 95)
                s = "Sam";
            else if (i == 96)
                s = "Samuel";
            else if (i == 97)
                s = "Shakti";
            else if (i == 98)
                s = "Shiva";
            else if (i == 99)
                s = "Simon";
            else if (i == 100)
                s = "Steven";
            else if (i == 101)
                s = "Théo";
            else if (i == 102)
                s = "Tom";
            else if (i == 103)
                s = "Tony";
            else if (i == 104)
                s = "Tyler";
            else if (i == 105)
                s = "Valentin";
            else if (i == 106)
                s = "Victor";
            else if (i == 107)
                s = "Vincent";
            else if (i == 108)
                s = "Vishnu";
            else
                s = "William";
            return s;
        }
        #endregion;
        static private Random gen = new Random();
        static DateTime RandomDay()
        {
            DateTime start = new DateTime(1948, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Tuple<string, DateTime>[] t =
            {
                Tuple.Create(RandomName(), RandomDay()),
                Tuple.Create(RandomName(), RandomDay()),
                Tuple.Create(RandomName(), RandomDay()),
                Tuple.Create(RandomName(), RandomDay()),
                Tuple.Create(RandomName(), RandomDay()),
                Tuple.Create(RandomName(), RandomDay()),
                Tuple.Create(RandomName(), RandomDay()),
                Tuple.Create(RandomName(), RandomDay()),
                Tuple.Create(RandomName(), RandomDay()),
                Tuple.Create(RandomName(), RandomDay()),
                Tuple.Create(RandomName(), RandomDay()),
                Tuple.Create(RandomName(), RandomDay()),
                Tuple.Create(RandomName(), RandomDay()),
                Tuple.Create(RandomName(), RandomDay()),
                Tuple.Create(RandomName(), RandomDay())
            };

            DateTime localDate = DateTime.Now;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i].Item2.Month == localDate.Month)
                {
                    int discount = (localDate.Year - t[i].Item2.Year) / 10 * 5;
                    if (t[i].Item2.Day == localDate.Day)
                        discount += 5;
                    Console.WriteLine($"{t[i].Item1} has {discount}% discount");
                }
            }

            Console.ReadKey();
        }
    }
}
