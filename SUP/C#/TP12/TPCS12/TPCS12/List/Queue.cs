using System;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace List
{
    public class Queue<T> : List<T>
    {
        public Queue()
            : base()
        {}
        
        public Queue(T elt)
            : base(elt)
        {}
        
        public T front()
        {
            if (head_ == null)
                throw new NullReferenceException("queue is empty");
            return head_.Data;
        }
        
        public void popFront()
        {
            delete(0);
        }

        public void pushBack(T elt)
        {
            Node<T> n = head_;
            int i = 0;
            for (; n != null; ++i)
                n = n.Next;

            insert(i, elt);
        }
    }
}