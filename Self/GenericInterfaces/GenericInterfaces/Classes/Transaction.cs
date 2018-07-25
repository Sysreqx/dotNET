using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericInterfaces
{
    class Transaction<T> where T : IAccount, IClient
    {
        public void Operate(T acc1 , T acc2, int sum)
        {
            if (acc1.CurrentSum >= sum)
            {
                acc1.Withdraw(sum);
                acc2.Put(sum);
                Console.WriteLine($"{acc1.Name} : {acc1.CurrentSum}\n{acc2.Name} : {acc2.CurrentSum}");
            }
        }
    }
}
