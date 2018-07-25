using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanit.com
{
    interface IAccount
    {
        // Текущая сумма на счету
        int CurrentSum { get; }
        // Положить деньги на счет
        void Put(int sum);
        // Взять со счета
        void Withdraw(int sum);
    }
}
