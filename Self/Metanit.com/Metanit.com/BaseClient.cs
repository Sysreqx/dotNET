using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanit.com
{
    abstract class BaseClient : IAccount, IClient
    {
        protected int _sum;
        public string Name { get; set; }
        public int CurrentSum { get => _sum; }
        public abstract void Put(int sum);
        public abstract void Withdraw(int sum);
    }
}
