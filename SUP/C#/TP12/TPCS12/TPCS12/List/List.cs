using System;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace List
{
    public class List<T>
    {
        public Node<T> head_;
        public Node<T> tail_;

        public List()
        {
            head_ = null;
            tail_ = null;
        }

        public List(T data)
        {
            head_ = new Node<T>(data);
            tail_ = head_;
        }

        public void print()
        {
            Node<T> n = head_;
            while (n.Next != tail_)
            {
                Console.Write(n.Data);
                Console.Write(", ");
                n = n.Next;
            }

            Console.WriteLine(tail_.Data);
        }
 
        public T this[int i]
        {
            get
            {
                Node<T> n = head_;
                int index = 0;
                for (; index < i && n != null; ++index)
                {
                    n = n.Next;
                }

                if (index < i)
                    throw new IndexOutOfRangeException("index is out of range");

                return n.Data;
            }

            set
            {
                Node<T> n = head_;
                int index = 0;
                for (; index < i && n != null; ++index)
                {
                    n = n.Next;
                }

                if (index < i)
                    throw new IndexOutOfRangeException("index is out of range");

                n.Data = value;
            }
        }

        public void insert(int i, T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (i == 0)
            {
                newNode.Next = head_;
                head_.Prev = newNode;
                head_ = newNode;
            }

            else
            {
                Node<T> n = head_;
                int index = 0;
                for (; index < i - 1 && n != null; ++index)
                {
                    n = n.Next;
                }

                if (index < i - 1)
                    throw new IndexOutOfRangeException("index is out of range");

                if (n == tail_)
                {
                    n.Next = newNode;
                    newNode.Prev = n;
                    tail_ = newNode;
                }

                else
                {
                    newNode.Next = n.Next;
                    newNode.Prev = n;
                    n.Next.Prev = newNode;
                    n.Next = newNode;
                }

            }
        }

        public void delete(int i)
        {
            if (i == 0)
            {
                head_.Next.Prev = null;
                head_ = head_.Next;
            }

            else
            {
                Node<T> n = head_;
                int index = 0;
                for (; index < i - 1 && n != null; ++index)
                {
                    n = n.Next;
                }

                if (index < i - 1)
                    throw new IndexOutOfRangeException("index is out of range");

                if (n == tail_)
                {
                    tail_.Prev.Next = null;
                    tail_ = tail_.Prev;
                }

                else
                {
                    n.Next = n.Next.Next;
                    n.Next.Prev = n;
                }
            }
        }
    }
}