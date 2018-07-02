using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToOop
{
    partial class Ip
    {
        // Behavior - in theory of OOP, Method - in C#
        #region Behavior
        // Input -> take IpV4Body
        // Output -> get IpV4Body converted to binary view
        // Example: 192.168.2.33 -> 11000000.10101000.00000010.00100001

        private bool ValidateIpV4Body(string input)
        {
            string[] splittedView = input.Split('.');
            bool isValidSubpart = splittedView.Length == 4;
            foreach (var item in splittedView)
            {
                int integer = int.Parse(item);
                if (integer < 0 || integer > 255)
                    return false;
            }
            return true;
        }

        public static int GetCurrentNumberOfIps()
        {
            return IpV4TotalCounter;
        }
        public string ToBinaryIpV4Body()
        {
            string returnValue = string.Empty;
            string [] bodySplitted = IpV4Body.Split('.');
            foreach (string item in bodySplitted)
            {
                string binaryView = Convert
                    .ToString(int.Parse(item), 2) + '.';
                returnValue += binaryView;
            }
            returnValue = returnValue.Remove(returnValue.Length - 1);

            return returnValue;
        }
        #endregion

        #region Constructors
        public Ip()
        {
            Id = IpV4TotalCounter;
            IpV4TotalCounter++;
            Console.WriteLine("IpV4 instance has been allocated in memory");
        }

        public Ip(string ip) : this()
        {
            IpV4Body = ip;
        }

        ~Ip()
        {
            Console.WriteLine("Ip has been killed...");
            IpV4TotalCounter--;
        }
        static Ip()
        {
            IpV4TotalCounter = 10;
            Console.WriteLine("Hello from Static Constructor");
        }
        #endregion
    }
}
