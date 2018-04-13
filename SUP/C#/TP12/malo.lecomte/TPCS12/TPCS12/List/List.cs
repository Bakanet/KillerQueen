using System;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace List
{
    public class List<T>
    {
        protected Node<T> head_;
        protected Node<T> tail_;

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

        /*public void insert(int i, T value)
        {
            Node<T> n = head_;
            int index = 0;
            for (; index < i - 1 && n != null; ++index)
            {
                n = n.Next;
            }

            if (index < i - 1)
                throw new IndexOutOfRangeException("index is out of range");

            Node<T> node = new Node<T>(value);
            node.Prev = n;
            node.Next = n.Next;
            node.Next.Prev = node;
            n.Next = node;
        }*/

        public void delete(int i)
        {
            //FIXME
            throw new NotImplementedException();
        }
    }
}