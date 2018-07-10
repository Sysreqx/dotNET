using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTour
{
    class Client
    {
        public string name { get; set; }
        public string email { get; set; }
        public string mobileNumber { get; set; }

        public Client(string name, string email, string mobileNumber)
        {
            this.name = name;
            this.email = email;
            this.mobileNumber = mobileNumber;
        }
    }
}
