using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IUser<int> user1 = new User<int>(6789);
            Console.WriteLine(user1.Id);    // 6789

            IUser<string> user2 = new User<string>("12345");
            Console.WriteLine(user2.Id);    // 12345
        }
    }
}
