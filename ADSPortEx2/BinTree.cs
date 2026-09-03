using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{

    class BinTree<T> where T : IComparable
    {
        protected Node<T> root;

        public BinTree()
        {
            root = null;
        }

        public BinTree(Node<T> node)
        {
            root = node;
        }

        public void InOrder(ref string buffer)
        {
            if (root == null)
            {
                Console.WriteLine("");
                buffer = "Tree is empty.";
                return;
            }

            inOrder(root, ref buffer);
        }

        private void inOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {
                inOrder(tree.Left, ref buffer);

                if (buffer.Length > 0)
                {
                    buffer += ", ";
                }

                buffer += tree.Data.ToString();
                inOrder(tree.Right, ref buffer);
            }
        }

        public void PreOrder(ref string buffer)
        {
            if (root == null)
            {
                Console.WriteLine("");
                buffer = "Tree is empty.";
                return;
            }

            preOrder(root, ref buffer);
        }

        private void preOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {

                if (buffer.Length > 0)
                {
                    buffer += ", ";
                }

                buffer += tree.Data.ToString();
                preOrder(tree.Left, ref buffer);
                preOrder(tree.Right, ref buffer);
            }
        }

        public void PostOrder(ref string buffer)
        {
            if (root == null)
            {
                Console.WriteLine("");
                buffer = "Tree is empty.";
                return;
            }

            postOrder(root, ref buffer);
        }

        private void postOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {
                postOrder(tree.Left, ref buffer);
                postOrder(tree.Right, ref buffer);

                if (buffer.Length > 0)
                {
                    buffer += ", ";
                }

                buffer += tree.Data.ToString();
            }
        }
    }
}
