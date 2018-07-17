using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Disk
    {
        int size;
        int freeSpace;

        public Disk(int size)
        {
            this.size = size;
            freeSpace = size;
        }
    }
}
