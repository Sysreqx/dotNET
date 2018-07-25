using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanit.com
{
    class BaseAction : IRunAction
    {
        public virtual void Move()
        {
            Console.WriteLine("Move in BaseAction");
        }
        public void Run()   
        {
            Console.WriteLine("Run");
        }
    }
}
