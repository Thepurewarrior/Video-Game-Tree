using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{

    class Node<T> where T : IComparable
    {
        private T data;
        private int balanceFactor = 0;
        public Node<T> Left, Right;

        public Node(T item)
        {
            data = item;
            Left = null;
            Right = null;
        }

        public T Data
        {
           get { return data; }
           set { data = value; }
        }

        public int BalanceFactor
        {
           get { return balanceFactor; }
           set { balanceFactor = value; }
        }

    }
}
