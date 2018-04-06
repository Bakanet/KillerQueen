using System;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace List
{
    public class Node<T>
    {
        protected T data_;
        protected Node<T> next_;
        protected Node<T> prev_;

        public Node(T elt)
        {
            next_ = null;
            prev_ = null;
            data_ = elt;
        }

        public T Data
        {
            get { return data_; }
            set { data_ = value; }
        }

        public Node<T> Next
        {
            get { return next_; }
            set { next_ = value; }
        }

        public Node<T> Prev
        {
            get { return prev_; }
            set { prev_ = value; }
        }
    }
}