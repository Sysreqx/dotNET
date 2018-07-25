using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanit.com
{
    class MyClass
    {
        static void Main()
        {
            BaseAction action1 = new HeroAction();
            action1.Move();            // Move in HeroAction

            IAction action2 = new HeroAction();
            action2.Move();

            BaseAction b = new BaseAction();
            b.Move();

            Console.ReadLine();
        }
    }
}
