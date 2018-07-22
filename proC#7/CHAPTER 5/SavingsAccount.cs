using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAPTER_5
{
    class SavingsAccount
    {
        // Instance-level data.
        public double currBalance;
        public static double currInterestRate;
        public SavingsAccount(double balance) => currBalance = balance;
        // A static constructor!
        static SavingsAccount()
        {
            Console.WriteLine("In static ctor!");
            currInterestRate = 0.04;
        }
        // Static members to get/set interest rate.
        public static void SetInterestRate(double newRate)
        { currInterestRate = newRate; }
        public static double GetInterestRate()
        { return currInterestRate; }
    }
}
