using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Folder : LogicalDisk, IPath, ITree
    {
        public DateTime date { get; set; }
        public LogicalDisk parent { get; set; }
        ArrayList folderData = new ArrayList();

        public Folder(string name, int size, LogicalDisk parent) : base(name, size)
        {
            this.parent = parent;
        }

        public override void Delete()
        {
            base.Delete();
            parent = null;
            folderData = null;
        }

        public new void ShowTree()
        {
            foreach (var i in folderData)
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

        public new void ShowPath()
        {
            foreach (var i in folderData)
            {
                Console.Write(i);
                Console.Write("/");
            }
        }
    }
}
