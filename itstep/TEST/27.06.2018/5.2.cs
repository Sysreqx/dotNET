using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 5
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            decimal LoanTotalAmountWithOverpayment, MonthlyIncome, PercentageOfSalaryForLoan;
            Console.WriteLine("Loan Total Amount With Overpayment");
            string line = Console.ReadLine();
            LoanTotalAmountWithOverpayment = decimal.Parse(line);
            Console.WriteLine("Monthly Income");
            line = Console.ReadLine();
            MonthlyIncome = decimal.Parse(line);
            Console.WriteLine("Percentage Of Salary For Loan");
            line = Console.ReadLine();
            PercentageOfSalaryForLoan = decimal.Parse(line);
            PercentageOfSalaryForLoan /= 100;
            Console.WriteLine();

            decimal monthsForCredit = LoanTotalAmountWithOverpayment / (MonthlyIncome * PercentageOfSalaryForLoan);
            for (int i = 0; i < Math.Ceiling(monthsForCredit); i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                DateTime localDate = DateTime.Now;
                CultureInfo us = new CultureInfo("en-US");
                Console.WriteLine("{0}", localDate.AddMonths(i).ToString(us));
                string KztToUsd = "341.21";
                string m = String.Format(us, "---------------------\nMonthly: {0:C}", LoanTotalAmountWithOverpayment / decimal.Parse(KztToUsd) / Math.Ceiling(monthsForCredit));
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(m);

                string KztToRub = "5.41";
                CultureInfo ru = new CultureInfo("ru-RU");
                m = String.Format(ru, "Monthly: {0:C}", LoanTotalAmountWithOverpayment / decimal.Parse(KztToRub) /  Math.Ceiling(monthsForCredit));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(m);

                CultureInfo kz = new CultureInfo("kk-KZ");
                m = String.Format(kz , "Monthly: {0:C}\n-------------------\n", LoanTotalAmountWithOverpayment / Math.Ceiling(monthsForCredit));
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(m);
            }
            Console.ReadKey();
        }
    }
}
