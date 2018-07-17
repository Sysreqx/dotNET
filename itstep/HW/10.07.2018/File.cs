using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class File : IPath, ITree
    {
        public string name { get; set; }
        public DateTime date{ get; set; }
        public int size { get; set; }
        public LogicalDisk parent { get; set; }

        public File(string name, int size, LogicalDisk parent)
        {
            this.name = name;
            this.parent = parent;
            this.size = size;
        }

        public void Delete()
        {
            name = null;
            size = 0;
            parent = null;
        }

        public void ShowPath()
        {

        }

        public void ShowTree()
        {
            throw new NotImplementedException();
        }
    }
}
