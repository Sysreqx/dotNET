using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericInterfaces
{
    class Client : IAccount, IClient
    {
        int _sum; // Переменная для хранения суммы
        public Client(string name, int sum)
        {
            Name = name;
            _sum = sum;
        }

        public string Name { get; set; }
        public int CurrentSum
        {
            get { return _sum; }
        }
        public void Put(int sum)
        {
            _sum += sum;
        }
        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;
            }
        }
    }
}
