using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
   class Program
   {
       static public int GetNthIndex(string s, char t, int n)
       {
           int count = 0;
           for (int i = 0; i < s.Length; i++)
           {
               if (s[i] == t)
               {
                   count++;
                   if (count == n)
                   {
                       return i;
                   }
               }
           }
           return -1;
       }

       static public string GetProtocol(string url)
       {
           string value;
           int n = GetNthIndex(url, '/', 2);
           value = url.Substring(0, n + 1);
           return value;
       }

       static public string GenerateShortURL(string url, Dictionary<string, string> urlShorted)
       {
           Random r = new Random();
           r.Next(65, 91); // A-Z 
           r.Next(97, 123); // a-z 
           for (int i = 0; i < 6; i++)
           {
               int c = r.Next(0, 2);
               if (c == 1)
                   url += Convert.ToChar(r.Next(65, 91)).ToString(); // A-Z 
               else
                   url += Convert.ToChar(r.Next(97, 123)).ToString(); // a-z 
           }

           foreach (var i in urlShorted)
           {
               if (i.Value == url)
                   GenerateShortURL(url, urlShorted);
               else
                   Console.WriteLine("URI not found");
           }
           return url;
       }

       static void Main(string[] args)
       {
           Dictionary<string, string> urlShorted = new Dictionary<string, string>();
           //string url = "https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/classes-and-structs/inheritance"; 
           string url = "fttps://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/classes-and-structs/inheritance";
           //string url = "sorax://www.google.kz/search?q=htttps//www&oq=htttps//www"; 

           string value = "";
           value = GetProtocol(url);

           value = GenerateShortURL(value, urlShorted);

           urlShorted.Add(url, value);

           Console.WriteLine(value);

           string s = Console.ReadLine();
           foreach (var i in urlShorted)
           {
               if (i.Value == s)
                   Console.WriteLine(i.Key);
               else
                   Console.WriteLine("URI not found");
           }

           Console.ReadLine();

       }
   }
}