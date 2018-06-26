using ChapterThree.DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChapterThree
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (args.Length > 0)
            //{
            //    if(args[0] == "-r")
            //    {
            //        string rootDirectory = Directory.GetCurrentDirectory();
            //        var subdirectories = Directory.GetDirectories(rootDirectory);

            //        foreach (var item in subdirectories)
            //        {
            //            Console.WriteLine(item);
            //        }
            //    }
            //}

            //var files = Directory.GetFiles(Directory.GetCurrentDirectory());

            //foreach (var item in files)
            //{
            //    Console.WriteLine(item);
            //}
            ////Console.WriteLine("Welcome to finance management app!");
            ////Console.WriteLine("1. Give salary");
            ////Console.WriteLine("2. Calculate taxes");
            //#region String Format Examples
            ////string[] names = { "Kaisar", "Dias", "Ekaterina", "Dana" };

            ////string invitationPattern = "Dear Mr./Mrs. PLACEHOLDER, we would like to invite...";
            ////string improvedInvitationPattern = "Dear Mr./Mrs. {0} {1} {2}, we would like to invite...";

            ////foreach (var item in names)
            ////{
            ////    //string updatedInvitation = invitationPattern.Replace("PLACEHOLDER", item);
            ////    //string updatedInvitation = String.Format(improvedInvitationPattern, item, "SAMA", "BAKA");

            ////    // $ - String Interpolation

            ////    //string moreBetterWay = $"Dear {item}, we would like to invite" + 
            ////    //        $"you on {DateTime.Today.DayOfWeek} to the party...";
            ////    //Console.WriteLine(moreBetterWay);
            ////}

            ////int myAge = 31;
            ////string myAgeInBinary = Convert.ToString(myAge, 16);

            ////string inputAge = "23";
            ////int age = int.Parse(inputAge);
            ////int ageAgain = Convert.ToInt32(inputAge);



            ////Console.WriteLine(myAgeInBinary);

            ////checked {
            ////    byte myValue = 100;
            ////    byte myNextValue = (byte)(myValue + 2);
            ////    myNextValue *= 2;
            ////    myNextValue += 50;
            ////    myNextValue += 3;
            ////    Console.WriteLine(myNextValue);
            ////}

            ////var myInteger = 23;
            ////var stringName = "Iskander";
            ////var dateTime = DateTime.Now;
            ////var id = Guid.NewGuid();
            ////var model = new ApplicationUserModel();

            ////Console.ForegroundColor = ConsoleColor.Green;
            ////Console.BackgroundColor = ConsoleColor.Red;

            ////while (true)
            ////{
            ////    DateTime currentTime = DateTime.Now;
            ////    Console.WriteLine(currentTime.ToLongTimeString());
            ////    Thread.Sleep(1000);
            ////    Console.Clear();
            ////}       
            ////Console.OutputEncoding = ASCIIEncoding.UTF8;
            ////double kaisarsSalary = 300000;
            ////kaisarsSalary *= 0.86;


            ////var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

            ////foreach (var item in cultures)
            ////{
            ////    Console.WriteLine(string.Format(item, "{0:C2}", kaisarsSalary));
            ////}
            ////Console.ReadLine();


            //List<string> items = new List<string>();
            //items.Add("Iskander");
            //items.Add("Savelii");

            //foreach (var item in items)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.OutputEncoding = ASCIIEncoding.UTF8;
            //double currentMoney = Double.Parse(Console.ReadLine());
            //double exchangeRatio = 340.1;
            //string newStr = String.Format(new CultureInfo("EN-us"), "{0:C}", currentMoney / exchangeRatio);
            //Console.WriteLine("Dollars: " + newStr);

            //int x = new Random().Next(0, 10) > 5 ? 10 : 0;

            string animal = "animal";
            string animus = "animus";

            int result = String.Compare(animal, animus);

            Console.WriteLine(result);


            Console.ReadLine();
        }
    }
}
