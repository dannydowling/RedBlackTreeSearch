using System;

namespace RedBlackTreeSearch
{
    public class RedBlackTree
    {

        public static Treenode guard;

        public static void LeftRotate(Treenode[] root, Treenode x)
        {
            Treenode y = x.right;
            x.right = y.left;
            // left child of y becomes the right child of x
            if (y.left != guard)
            {
                y.left.parent = x;
            }
            // y becomes the root of the subtree
            y.parent = x.parent;

            if (x.parent == guard) // if x was root now y is the root
            {
                root[0].CopyFrom(y);
            }
            else if (x == x.parent.left) // if x was in the left of the parent
            {
                x.parent.left = y;
            }
            else
            {
                x.parent.right = y; // if x was in the right of the parent
            }
            y.left = x; // x becomes the left child of y
            x.parent = y;
        }

        public static void RightRotate(Treenode[] root, Treenode x)
        {
            Treenode y = x.left;
            x.left = y.right;

            if (y.right != guard)
            {
                y.right.parent = x;
            }

            y.parent = x.parent;

            if (x.parent == guard)
            {
                //ORIGINAL LINE: *root = y;
                root[0].CopyFrom(y);
            }
            else if (x == x.parent.right)
            {
                x.parent.right = y;
            }
            else
            {
                x.parent.left = y;
            }
            y.right = x;
            x.parent = y;
        }

        public delegate int comparatorDelegate(object UnnamedParameter, object UnnamedParameter2);

        public static void insertion(Treenode[] root, object data, comparatorDelegate comparator)
        {
            Treenode z = new Treenode();
            z.data = data;
            z.left = guard;
            z.right = guard;
            z.parent = guard;
            if (root[0] == guard)
            {
                z.color = 'B';

                //ORIGINAL LINE: *root = z;
                root[0].CopyFrom(z);
                return;
            }
            Treenode y = guard;
            Treenode x = root[0];

            while (x != guard)
            { // stop when x finds the last node and save it at y, x becomes guard
                y = x;
                if (comparator(z.data, x.data) < 0)
                {
                    x = x.left;
                }
                else
                {
                    x = x.right;
                }
            }
            z.parent = y;

            if (comparator(z.data, y.data) < 0) //put z right or left,depends on the id
            {
                y.left = z;
            }
            else
            {
                y.right = z;
            }

            z.color = 'R';
            Fixedinsertion(root, z);
        }

        public static void Fixedinsertion(Treenode[] root, Treenode z)
        { // we insert z in this function with color red
            Treenode y;
            while (z.parent.color == 'R')
            { // if both child and parent are red
                if (z.parent == z.parent.parent.left)
                {
                    y = z.parent.parent.right; // y is the uncle
                    if (y.color == 'R')
                    { // if uncle is red, then all three are red
                        z.parent.color = 'B';
                        y.color = 'B';
                        z.parent.parent.color = 'R';
                        z = z.parent.parent;
                    }
                    else
                    { // if uncle is black
                        if (z == z.parent.right)
                        { // if we have a triangle form
                            z = z.parent;
                            LeftRotate(root, z); // we make it a line
                        }
                        z.parent.color = 'B'; //we fix the colors in the line, z is the left last node of the subtree
                        z.parent.parent.color = 'R';
                        RightRotate(root, z.parent.parent);
                    }
                }
                else if (z.parent == z.parent.parent.right)
                { // same thing in the right side
                    y = z.parent.parent.left;
                    if (y.color == 'R')
                    {
                        z.parent.color = 'B';
                        y.color = 'B';
                        z.parent.parent.color = 'R';
                        z = z.parent.parent;
                    }
                    else
                    {
                        if (z == z.parent.left)
                        {
                            z = z.parent;
                            RightRotate(root, z);
                        }
                        z.parent.color = 'B';
                        z.parent.parent.color = 'R';
                        LeftRotate(root, z.parent.parent);
                    }
                }
            }
            root.color = 'B'; //root has to be always black
        }

        public static void deleteTree(Treenode root)
        {
            if (root == guard)
            {
                return;
            }
            deleteTree(root.left);
            deleteTree(root.right);
            //free(root->data);
        }
    }
}