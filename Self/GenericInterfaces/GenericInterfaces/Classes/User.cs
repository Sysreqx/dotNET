using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericInterfaces.Classes
{
    class User<T> : IUser<T>
    {
        T _id;
        public User(T id)
        {
            _id = id;
        }
        public T Id { get { return _id; } }
    }   
}
