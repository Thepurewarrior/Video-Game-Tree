using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{

    class AVLTree<T> : BSTree<T> where T : IComparable
    {

        public new void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
            {
                tree = new Node<T>(item);
                return;
            }
            if (item.CompareTo(tree.Data) < 0)
                insertItem(item, ref tree.Left);

            else if (item.CompareTo(tree.Data) > 0)
                insertItem(item, ref tree.Right);

            tree.BalanceFactor = height(tree.Left) - height(tree.Right);

            if (tree.BalanceFactor > 1 && item.CompareTo(tree.Left.Data) < 0)
            {
                tree = RightRotate(tree);
            }

            else if (tree.BalanceFactor < -1 && item.CompareTo(tree.Right.Data) > 0)
            {
                tree = LeftRotate(tree);
            }

            else if (tree.BalanceFactor > 1 && item.CompareTo(tree.Left.Data) > 0)
            {
                tree.Left = LeftRotate(tree.Left);
                tree = RightRotate(tree);
            }

            else if (tree.BalanceFactor < -1 && item.CompareTo(tree.Right.Data) < 0)
            {
                tree.Right = RightRotate(tree.Right);
                tree = LeftRotate(tree);
            }
        }

        public new void RemoveItem(T item)
        {
            removeItem(item, ref root);
        }

        private void removeItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                return;

            if (item.CompareTo(tree.Data) < 0)
                removeItem(item, ref tree.Left);
            else if (item.CompareTo(tree.Data) > 0)
                removeItem(item, ref tree.Right);
            else
            {
                VideoGame currentGame = (VideoGame)(object)tree.Data;
                VideoGame newGame = (VideoGame)(object)item;

                if (currentGame.Title == newGame.Title)
                {
                    if (tree.Left == null && tree.Right == null)
                    {
                        tree = null;
                    }
                    else if (tree.Left == null)
                    {
                        tree = tree.Right;
                    }
                    else if (tree.Right == null)
                    {
                        tree = tree.Left;
                    }
                    else
                    {
                        Node<T> successor = FindMin(tree.Right);
                        tree.Data = successor.Data;
                        removeItem(successor.Data, ref tree.Right);
                    }
                }
            }

            if (tree != null)
            {
                tree.BalanceFactor = height(tree.Left) - height(tree.Right);

                if (tree.BalanceFactor > 1)
                {
                    if (balanceFactor(tree.Left) >= 0)
                        tree = RightRotate(tree);
                    else
                    {
                        tree.Left = LeftRotate(tree.Left);
                        tree = RightRotate(tree);
                    }
                }
                else if (tree.BalanceFactor < -1)
                {
                    if (balanceFactor(tree.Right) <= 0)
                        tree = LeftRotate(tree);
                    else
                    {
                        tree.Right = RightRotate(tree.Right);
                        tree = LeftRotate(tree);
                    }
                }
            }
        }

        public int Height()
        {
            return height(root);
        }

        private int height(Node<T> tree)
        {
            if (tree == null)
                return 0;
            else
                return 1 + Math.Max(height(tree.Left), height(tree.Right));
        }
        public int BalanceFactor()
        {
            return balanceFactor(root); 
        }

        private int balanceFactor(Node<T> node)
        {
            if (node == null)
                return 0; 

            return height(node.Left) - height(node.Right);
        }

        private Node<T> RightRotate(Node<T> y)
        {
            Node<T> x = y.Left; 
            Node<T> tempR = x.Right;

            x.Right = y;
            y.Left = tempR;

            return x;
        }

        private Node<T> LeftRotate(Node<T> x)
        {
            Node<T> y = x.Right;
            Node<T> tempL = y.Left;

            y.Left = x;
            x.Right = tempL;

            return y;
        }

        private Node<T> FindMin(Node<T> tree)
        {
            while (tree.Left != null)
            {
                tree = tree.Left;
            }
            return tree;
        }
    }
}
