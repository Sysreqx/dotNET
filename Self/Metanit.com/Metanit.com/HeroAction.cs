using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanit.com
{
    class HeroAction : BaseAction
    {
        public override void Move()
        {
            Console.WriteLine("Move in HeroAction");
        }

        // Сокрытие (shadowing / method hiding). // Move in BaseAction.
        //public new void Move()
        //{
        //    Console.WriteLine("Move in HeroAction");
        //}

        // Третий вариант - повторная реализация интерфейса в классе-наследнике: // Move in HeroAction
        //public new void Move()
        //{
        //    Console.WriteLine("Move in HeroAction");
        //}
    }
}
