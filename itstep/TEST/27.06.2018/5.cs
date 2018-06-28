using System;
using System.Collections.Generic;
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
            double LoanTotalAmountWithOverpayment, MonthlyIncome, PercentageOfSalaryForLoan;

            Console.WriteLine("LoanTotalAmountWithOverpayment");
            string line = Console.ReadLine();
            LoanTotalAmountWithOverpayment = double.Parse(line);
            Console.WriteLine("MonthlyIncome");
            line = Console.ReadLine();
            MonthlyIncome = double.Parse(line);
            Console.WriteLine("PercentageOfSalaryForLoan");
            line = Console.ReadLine();
            PercentageOfSalaryForLoan = double.Parse(line);
            PercentageOfSalaryForLoan /= 100.0;

            double monthsForCredit = LoanTotalAmountWithOverpayment / (MonthlyIncome * PercentageOfSalaryForLoan);
            Console.WriteLine(Math.Ceiling(monthsForCredit) + " months");
            Console.ReadKey();
        }
    }
}
