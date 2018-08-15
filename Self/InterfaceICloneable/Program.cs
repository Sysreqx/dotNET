using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceICloneable.Classes;
using InterfaceICloneable.Interfaces;

namespace InterfaceICloneable
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person { Name = "Tom", Age = 23, Work = new Company { Name = "Microsoft" } };
            Person p2 = (Person)p1.Clone();
            p2.Work.Name = "Google";
            p2.Name = "Kaisar";
            p2.Age = 21;
            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Console.Read();
        }
    }
}
