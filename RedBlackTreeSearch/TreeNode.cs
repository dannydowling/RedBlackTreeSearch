using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeSearch
{
    public class Treenode
    {
        public object data;
        public char color;
        public Treenode left;
        public Treenode right;
        public Treenode parent;

        internal static unsafe ref Treenode CopyFrom(Treenode y)
        {            
            Treenode* ptr = &y;
            return ref ptr;
        }
     
    }
}
