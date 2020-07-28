using System;
using System.Collections.Generic;
using System.Text;

namespace CookTime.Models
{
    public class Node<T> where T : IComparable
    {
        public T data;
        public Node<T> prev;
        public Node<T> next;

        public Node(T val)
        {
            this.data = val;
        }
        public Node()
        {
        }
    }
}
