using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> cities = ReadFromFile();
            //// Weather by city 
            //Console.WriteLine("Choise city below"); 
            //foreach (var item in cities) 
            // Console.WriteLine(item.Value); 
            //string choisedCity = Console.ReadLine(); 
            //var findeCity = cities.FirstOrDefault(w => w.Key == choisedCity || w.Value.ToLower() == choisedCity.ToLower()); 
            //RefWeather(findeCity.Key); 
            // Weather by city 

            HootestWeatherByCity(cities);
            Console.Read();
        }
        //• пары «код-имя города» хранить в файле, что бы программа позволяла добавлять новые города, не требуя перекомпиляции; 
        static Dictionary<string, string> ReadFromFile()
        {
            string path = @"C:\Users\SysRq\source\repos\Weather\Weather\cities.txt";
            Dictionary<string, string> cities = new Dictionary<string, string>();

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    char ch = '-';
                    int indexOfChar = line.IndexOf(ch);
                    string sub = line.Substring(0, indexOfChar);
                    string sub2 = line.Substring(indexOfChar + 1, line.Length - 1 - indexOfChar);
                    cities.Add(sub, sub2);
                }
            }
            return cities;
        }
        // • найти самую теплую погоду в представленных городах; 
        static void HootestWeatherByCity(Dictionary<string, string> cities)
        {
            int HottestWeather = -75;
            string City = "qwertt";
            XmlDocument xDoc = new XmlDocument();
            foreach (var item in cities)
            {

                string s = string.Format("http://informer.gismeteo.by/rss/" + $"{item.Key}" + ".xml");
                xDoc.Load(s);

                //var elemets = xDoc.SelectNodes("rss/channel"); 
                // получим корневой элемент 
                var xRoot = xDoc.DocumentElement;

                // обход всех узлов в корневом элементе 
                foreach (XmlNode xnode in xRoot.ChildNodes)
                {
                    foreach (XmlNode channel in xnode.ChildNodes)
                    {
                        // получаем атрибут name 
                        if (channel.Name == "item")
                        {
                            var t = channel.SelectSingleNode("title");
                            var z = channel.SelectSingleNode("description");
                            string s1 = t.InnerText.ToLower();
                            string s2 = z.InnerText.ToLower();
                            if (s1.Contains("день") && s2.Contains(".."))
                            {
                                char ch = ':';
                                int indexOfChar = s1.IndexOf(ch);
                                string sub = s1.Substring(0, indexOfChar);

                                char ch2 = '.';
                                int idOfDot = s2.IndexOf(ch2);
                                string sub2 = s2.Substring(idOfDot + 2, 2);

                                if (HottestWeather < int.Parse(sub2))
                                {
                                    HottestWeather = int.Parse(sub2);
                                    City = sub;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(City + " " + HottestWeather);
        }
        static void RefWeather(string city)
        {
            XmlDocument xDoc = new XmlDocument();
            string s = string.Format("http://informer.gismeteo.by/rss/" + $"{city}" + ".xml");
            xDoc.Load(s);

            //var elemets = xDoc.SelectNodes("rss/channel"); 
            // получим корневой элемент 
            var xRoot = xDoc.DocumentElement;

            // обход всех узлов в корневом элементе 
            foreach (XmlNode xnode in xRoot.ChildNodes)
            {
                foreach (XmlNode channel in xnode.ChildNodes)
                {
                    // получаем атрибут name 
                    if (channel.Name == "item")
                    {
                        var t = channel.SelectSingleNode("title");
                        Console.WriteLine(t.InnerText);
                        var z = channel.SelectSingleNode("description");
                        Console.WriteLine(z.InnerText);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}