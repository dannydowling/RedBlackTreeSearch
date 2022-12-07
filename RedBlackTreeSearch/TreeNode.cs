using System;
using System.Collections.Generic;
using System.Linq;
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

        internal ref object CopyFrom(Treenode y)
        {
            return ref(y);
        }
    }
}
