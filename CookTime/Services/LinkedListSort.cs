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
            public T data;
            public Node<T> prev;
            public Node<T> next;

            public Node(T val)
            {
                this.data = val;
            }
        }

        // Inserta un nodo al principio de la lista (similar a una pila)
        void push(T val)
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

        static Node<T> bubbleSort(Node<T> start)
        {
            int swapped;
            Node<T> node;

            // Revisa si la lista está vacía
            if (start == null)
                return null;

            do
            {
                swapped = 0;
                node = start;

                while (node.next != null)
                {
                    // Sube los valores si son mayores
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

            // Partición de la lista
            Node<T> pivot_prev = paritionLast(start, end);
            quickSort(start, pivot_prev);

            // Si el pivote se mueve al principio, el pivote y el primer nodo son iguales, por lo tanto escoje al que está después del pivote
            if (pivot_prev != null &&
                pivot_prev == start)
                quickSort(pivot_prev.next, end);

            // Si el pivote está ebtre los nodos de la lista se empieza desde el que está dos nodos adelante del pivote, ya que pivot_prev ya almacena un pivote
            else if (pivot_prev != null &&
                    pivot_prev.next != null)
                quickSort(pivot_prev.next.next, end);
        }

        // Toma el primer y el último nodo sin romper ningún enlace en la lista enlazada
        Node<T> paritionLast(Node<T> start, Node<T> end)
        {
            if (start == end ||
               start == null || end == null)
                return start;

            Node<T> pivot_prev = start;
            Node<T> curr = start;
            T pivot = end.data;

            // Se itera hasta que el que está antes del último. No se necesita iterar hasta el final porque el último nodo es el pivote
            T temp;
            while (start != end)
            {

                if (start.data.CompareTo(pivot) < 0)
                {
                    // Sigue al último dato modificado
                    pivot_prev = curr;
                    temp = curr.data;
                    curr.data = start.data;
                    start.data = temp;
                    curr = curr.next;
                }
                start = start.next;
            }

            // El índice evaluado, el índice a evaluar u el último nodo cambian de posición
            temp = curr.data;
            curr.data = pivot;
            end.data = temp;

            // retorna al que está antes de current, ya que current apunta al pivote
            return pivot_prev;
        }

        // Radix sort lo utiliza para obtener el número máximo
        private int getMax(int[] arr, int n)
        {
            int mx = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > mx)
                    mx = arr[i];
            return mx;
        }

        // Radix sot lo utiliza si n / exp > 0
        private void countSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n]; // output array  
            int i;
            int[] count = new int[10];

            // Inicializa los elementos del array
            for (i = 0; i < 10; i++)
                count[i] = 0;

            // Suma 1 cada vez que se encuentra un dígito en su casilla correspondiente (ej: suma 1 en la casilla 4 si ve 104 y busca en unidades)
            for (i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            // Se le suma el valor anterior a cada valor
            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Construye el array resultante ordenado en el dígito correspondiente
            for (i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Se copia el array resultante en el array a ordenar
            for (i = 0; i < n; i++)
                arr[i] = output[i];
        }

        // Función principal de radix sort
        public void radixSort(int[] arr)
        {

            int length = arr.Length;
            // Busca el número máximo para conocer su cantidad de dígitos
            int maxNum = getMax(arr, length);

            // Hace count sort por cada dígito que tenga el número mayor. Cuando el loop sigue se multiplica 10 a exp, con un valor inicial de 1. El loop para cuando
            // n/exp deja de ser un número mayor que 0.
            for (int exp = 1; maxNum / exp > 0; exp *= 10)
                countSort(arr, length, exp);
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
