using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceICloneable.Classes;

namespace InterfaceICloneable
{
    class Person : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Work { get; set; }

        public object Clone()
        {
            Company company = new Company() { Name = "Microsoft" };
            return new Person
            {
                Name = Name,
                Age = Age,
                Work = company
            };
        }

        public override string ToString()
        {
            return $"Name = {Name}\nAge = {Age}\nWork = {Work.Name}\n";
        }
    }
}
