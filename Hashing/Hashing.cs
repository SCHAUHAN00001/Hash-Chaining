using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    internal class Program
    {
        public class Node
        {
            public int element;
            public Node Next;
            public Node(int e, Node n)
            {
                element = e;
                Next = n;
            }
        }
        class LinkedList
        {
            private Node head;
            private Node tail;
            private int size;
            public LinkedList()
            {
                head = null;
                tail = null;
                size = 0;
            }
            public int length()
            {
                return size;
            }
            public bool isEmpty()
            {
                return size == 0;
            }
            public void addLast(int e)
            {
                Node newest = new Node(e, null);
                if (isEmpty())
                {
                    head = newest;
                    tail = newest;
                }
                else
                {
                    tail.Next = newest;
                    tail = newest;


                }
                size = size + 1;
            }
            public void addFirst(int e)
            {
                Node newest = new Node(e, null);
                if (isEmpty())
                {
                    head = newest;
                    tail = newest;
                }
                else
                {
                    newest.Next = head;
                    head = newest;
                }
                size = size + 1;
            }
            public void addAnywhere(int e, int position)
            {
                Node newest = new Node(e, null);
                Node p = head;
                int i = 1;
                while (i < position - 1)
                {
                    p = p.Next;
                    i = i + 1;
                }
                newest.Next = p.Next;
                p.Next = newest;
                size = size + 1;

            }
            public int removeFirst()
            {
                if (isEmpty())
                {
                    Console.WriteLine("List is empty");
                    return -1;
                }
                int e = head.element;
                head = head.Next;
                size = size - 1;
                if (isEmpty())
                {
                    tail = null;
                }
                return e;
            }
            public int removeLast()
            {
                if (isEmpty())
                {
                    Console.WriteLine("List is empty");
                    return -1;

                }
                Node p = head;
                int i = 1;
                while (i < length() - 1)
                {
                    p = p.Next;
                    i = i + 1;

                }
                tail = p;
                p = p.Next;
                int e = p.element;
                tail.Next = null;
                size = size - 1;
                return e;

            }
            public int removeAnywhere(int position)
            {
                Node p = head;
                int i = 1;
                while (i < position - 1)
                {
                    p = p.Next;
                    i = i + 1;
                }
                int e = p.Next.element;
                p.Next = p.Next.Next;
                size = size - 1;
                return e;

            }
            public int Searching(int key)
            {
                Node p = head;
                int index = 0;
                while (p != null)
                {
                    if (p.element == key)
                    {
                        return index;
                    }
                    p = p.Next;
                    index++;

                }
                return -1;
            }
            public void InsertSortedList(int e)
            {
                Node newest = new Node(e, null);
                if (isEmpty())
                {
                    head = newest;


                }
                else
                {
                    Node p = head;
                    Node q = head;
                    while (p != null && p.element < e)
                    {
                        q = p;
                        p = p.Next;
                    }
                    if (p == head)
                    {
                        newest.Next = head;
                        head = newest;
                    }
                    else
                    {
                        newest.Next = q.Next;
                        q.Next = newest;

                    }
                }
                size = size + 1;
            }
            public void display()
            {
                Node p = head;
                while (p != null)
                {
                    Console.Write(p.element + " ");
                    p = p.Next;
                }
                Console.WriteLine();
            }
        }
        class HashChain
        {
            int hashtablesize;
            LinkedList[] hashtable;
            public HashChain()
            {
                hashtablesize = 10;
                hashtable = new LinkedList[hashtablesize];
                for(int i = 0; i < hashtablesize; i++)
                {
                    hashtable[i] = new LinkedList();
                }
            }
            public int hashCode(int key)
            {
                return key % hashtablesize;
            }
            public void insert(int element)
            {
                int i = hashCode(element);
                hashtable[i].InsertSortedList(element);
            }
            public bool search(int key)
            {
                int i = hashCode(key);
                return hashtable[i].Searching(key) != -1;
            }
            public void display()
            {
                for(int i = 0;i < hashtablesize; i++)
                {
                    Console.WriteLine("["+i+"]");
                    hashtable[i].display();
                }
                Console.WriteLine() ;
            }
            static void Main(string[] args)
            {
                HashChain h = new HashChain();
                h.insert(54);
                h.insert(68);
                h.insert(74);
                h.insert(28);
                h.insert(36);
                h.display();
                Console.ReadLine();

            }

            }
    }
}
