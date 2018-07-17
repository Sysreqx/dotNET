using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class LogicalDisk : IPath, ITree
    {
        public string name { get; set; }
        public int size { get; set; }
        int freeSpace { get; set; }
        ArrayList LD_data = new ArrayList();

        public LogicalDisk(string name, int size)
        {
            this.name = name;
            this.size = size;
            freeSpace = size;
        }

        public virtual void Delete()
        {
            name = null;
            size = 0;
            freeSpace = 0;
            LD_data = null;
        }

        public void Format()
        {
            size = 0;
            freeSpace = 0;
            LD_data = null;
        }

        public void ShowPath()
        {
            foreach (var i in LD_data)
            {
                Console.Write(i);
                Console.Write("/");
            }
        }

        public void ShowTree()
        {
            foreach (var i in LD_data)
            {
                if (i is Folder)
                {
                    Console.WriteLine("\t" + i);
                }
                else
                {
                    Console.WriteLine("\t" + i);
                }
            }
        }
    }
}
