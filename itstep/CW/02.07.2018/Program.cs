using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToOop
{
    enum AnimalMood
    {
        Happy, Neutral, Angry
    }

    class CurrencyCalculator
    {
        private static CurrencyCalculator [] _calculatorInstances = new CurrencyCalculator[] { null, null };
        private static int _nextElementIndex = 0; 
        public static CurrencyCalculator GetCurrencyCalculator()
        {
            if (_nextElementIndex > 1)
            {
                _nextElementIndex = 0;
            }
            if (_calculatorInstances[_nextElementIndex] == null)
            {               
                _calculatorInstances[_nextElementIndex] = new CurrencyCalculator();
                int currentId = _nextElementIndex;
                _nextElementIndex++;
                return _calculatorInstances[currentId];
            }
            else return _calculatorInstances[_nextElementIndex];
        }
        private CurrencyCalculator() { }
    }
    class Animal
    {
        // Class (Object) = State + Behavior 

        #region State
        public string PettyName;
        public bool IsDomestic;
        public double Weight;
        public int Age;
        public string OwnerName;
        public DateTime LastFeededTime;
        public AnimalMood Mood;
        #endregion

        #region Behavior
        public void AskForFeed()
        {

        }

        public void ChangeMood(AnimalMood newMood)
        {

        }

        public void Speak()
        {

        }
        #endregion
    }

    // Fields, Methods and Constructors without STATIC modifier belongs to OBJECT-level

    // Access Modifies = { Public, Internal, Protected, Protected Internal, Protected Private, Private }
    // Class = { Fields, Properties, Methods, Constructors, Desctructors }
    partial class Ip
    {
        // State - in theory of OOP, Field - in C#
        #region State
        public string IpV4Body;
        public int Id;
        private static int IpV4TotalCounter;
        #endregion
    }
    class Program
    {
        static void DemoDestructor()
        {
            Ip ekaterinaIp = new Ip("192.168.21.12");
            GC.SuppressFinalize(ekaterinaIp);
        }
        static void Main(string[] args)
        {
            Ip ekaterinaIp = new Ip("192.168.21.12");
            Ip kaisarIp = new Ip("228.228.228.322");
            Ip zaharIp = new Ip("666.666.666.666");

            ekaterinaIp.IpV4Body = "192.168.21.12";
            kaisarIp.IpV4Body = "228.228.228.322";
            zaharIp.IpV4Body = "666.666.666.666";

            string ekaterinaFormatted = $"IPv4 User-Friendly = {ekaterinaIp.IpV4Body} :" +
                $"IPv4 Machine-Friendly = {ekaterinaIp.ToBinaryIpV4Body()}";

            string kaisarFormatted = $"IPv4 User-Friendly = {kaisarIp.IpV4Body} :" +
                $"IPv4 Machine-Friendly = {kaisarIp.ToBinaryIpV4Body()}";

            string zaharFormatted = $"IPv4 User-Friendly = {zaharIp.IpV4Body} :" +
                $"IPv4 Machine-Friendly = {zaharIp.ToBinaryIpV4Body()}";

            Console.WriteLine(ekaterinaFormatted);
            Console.WriteLine(kaisarFormatted);
            Console.WriteLine(zaharFormatted);

            Console.WriteLine(Ip.GetCurrentNumberOfIps());

            var a = CurrencyCalculator.GetCurrencyCalculator();
            var b = CurrencyCalculator.GetCurrencyCalculator();
            var c = CurrencyCalculator.GetCurrencyCalculator();

            if(a == c)
            {
                Console.WriteLine("Reference equals");
            }
            Console.ReadLine();
        }
    }
}
