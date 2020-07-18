using System;
using System.Collections.Generic;
using System.Text;

namespace CookTime.Services
{
    public class LinkedListSort<T> where T : IComparable
    {

        public Node<T> head;
        public Node<T> sorted;

        public class Node<T> where T : IComparable
        {
            public T val;
            public Node<T> next;

            public Node(T val)
            {
                this.val = val;
            }
        }

        // Inserta un nodo al principio de la lista (similar a una pila)
        void push(T val)
        {
            Node<T> newnode = new Node<T>(val);
            newnode.next = head;
            head = newnode;
        }

        // Ordena la lista usando insertion sort con el primer nodo de la lista
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

        // Inserta los nodos en orden
        private void sortedInsert(Node<T> newnode)
        {
            // Caso especial para el head
            if (sorted == null || sorted.val.CompareTo(newnode.val) >= 0)
            {
                newnode.next = sorted;
                sorted = newnode;
            }
            else
            {
                Node<T> current = sorted;

                // Busca dónde insertar el nodo
                while (current.next != null &&
                        current.next.val.CompareTo(newnode.val) < 0)
                {
                    current = current.next;
                }
                newnode.next = current.next;
                current.next = newnode;
            }
        }

        // Imprime la lista
        void printlist(Node<T> head)
        {
            while (head != null)
            {
                Console.Write(head.val + " ");
                head = head.next;
            }
        }

        // Prueba
        public static void Main(String[] args)
        {
            LinkedListSort<Int32> list = new LinkedListSort<Int32>();
            list.push(5);
            list.push(20);
            list.push(4);
            list.push(3);
            list.push(30);
            Console.WriteLine("Lista antes de ordenar");
            list.printlist(list.head);
            list.insertionSort(list.head);
            Console.WriteLine("\nLista después de ordenar");
            list.printlist(list.head);
        }
    }

}
