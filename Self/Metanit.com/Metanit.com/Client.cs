using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanit.com
{
    class Client : BaseClient
    {
        public Client(string name, int sum)
        {
            Name = name;
            _sum = sum;
        }
        public override void Put(int sum)
        {
            _sum += sum;
        }
        public override void Withdraw(int sum)
        {
            if (sum <= _sum) _sum -= sum;
        }
    }
}
