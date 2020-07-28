using System;
using System.Collections.Generic;
using System.Text;
using CookTime.Models;

namespace CookTime.Services
{
    public class LinkedListSort<T> where T : IComparable
    {

        public Node<T> head;
        public Node<T> sorted;



        // Inserta un nodo al principio de la lista (similar a una pila)
        public void push(T val)
        {
            Node<T> newnode = new Node<T>(val);
            newnode.next = head;
            if (head != null)
            {
                head.prev = newnode;
            }
            head = newnode;
        }

        void addLast(T data)
        {
            if (head == null)
            {
                head = new Node<T>(data);
                return;
            }

            Node<T> curr = head;
            while (curr.next != null)
                curr = curr.next;

            Node<T> newNode = new Node<T>(data);
            curr.next = newNode;
            newNode.prev = curr;
        }

        // takes first and last node, 
        // but do not break any links in  
        // the whole linked list 
        Node<T> paritionLast(Node<T> start, Node<T> end)
        {
            if (start == end ||
               start == null || end == null)
                return start;

            Node<T> pivot_prev = start;
            Node<T> curr = start;
            T pivot = end.data;

            // iterate till one before the end,  
            // no need to iterate till the end  
            // because end is pivot 
            T temp;
            while (start != end)
            {

                if (start.data.CompareTo(pivot) < 0)
                {
                    // keep tracks of last modified item 
                    pivot_prev = curr;
                    temp = curr.data;
                    curr.data = start.data;
                    start.data = temp;
                    curr = curr.next;
                }
                start = start.next;
            }

            // swap the position of curr i.e. 
            // next suitable index and pivot 
            temp = curr.data;
            curr.data = pivot;
            end.data = temp;

            // return one previous to current 
            // because current is now pointing to pivot 
            return pivot_prev;
        }

        public Node<T> bubbleSort()
        {
            return bubbleSort(head);
        }

         public static Node<T> bubbleSort(Node<T> start)
        {
            int swapped;
            Node<T> node;

            // Checking for empty list  
            if (start == null)
                return null;

            do
            {
                swapped = 0;
                node = start;

                while (node.next != null)
                {
                    if (node.data.CompareTo(node.next.data) > 0)
                    {
                        T data = node.data;
                        node.data = node.next.data;
                        node.next.data = data;
                        swapped = 1;
                    }
                    node = node.next;
                }
            }
            while (swapped != 0);
            return start;
        }

        void quickSort(Node<T> start, Node<T> end)
        {
            if (start == end)
                return;

            // split list and partion recurse 
            Node<T> pivot_prev = paritionLast(start, end);
            quickSort(start, pivot_prev);

            // if pivot is picked and moved to the start, 
            // that means start and pivot is same  
            // so pick from next of pivot 
            if (pivot_prev != null &&
                pivot_prev == start)
                quickSort(pivot_prev.next, end);

            // if pivot is in between of the list, 
            // start from next of pivot,  
            // since we have pivot_prev, so we move two nodes 
            else if (pivot_prev != null &&
                    pivot_prev.next != null)
                quickSort(pivot_prev.next.next, end);
        }

        static void Sort(int[] arr)
        {
            int temp = 0;
            int i, j;
            int[] tmp = new int[arr.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < arr.Length; ++i)
                {
                    bool move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        arr[i - j] = arr[i];
                    else
                        tmp[j++] = arr[i];
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);
            }
        }

        // Ordena la lista usando insertion sort con el primer nodo de la lista (InsertionSort)
        void insertionSort(Node<T> headref)
        {
            sorted = null;
            Node<T> current = headref;

            // Recorre la lista insertando los nodos en orden con sortedInsert
            while (current != null)
            {
                Node<T> next = current.next;
                sortedInsert(current);
                current = next;
            }

            head = sorted;
        }

        // Inserta los nodos en orden (InsertionSort)
        private void sortedInsert(Node<T> newnode)
        {
            // Caso especial para el head
            if (sorted == null || sorted.data.CompareTo(newnode.data) >= 0)
            {
                newnode.next = sorted;
                sorted = newnode;
            }
            else
            {
                Node<T> current = sorted;

                // Busca dónde insertar el nodo
                while (current.next != null &&
                        current.next.data.CompareTo(newnode.data) < 0)
                {
                    current = current.next;
                }
                newnode.next = current.next;
                current.next = newnode;
            }
        }
    }

}
