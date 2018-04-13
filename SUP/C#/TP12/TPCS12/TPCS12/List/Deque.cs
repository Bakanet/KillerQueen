using System;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace List
{
    public class Dequeue<T> : List<T>
    {
        public Dequeue()
            : base()
        {}
        
        public Dequeue(T elt)
            : base(elt)
        {}
        
        public T front()
        {
            if (head_ == null)
                throw new NullReferenceException("deque is empty");

            return head_.Data;
        }
        
        public T back()
        {
            if (tail_ == null)
                throw new NullReferenceException("deque is empty");

            return tail_.Data;
        }
        
        public virtual void popBack()
        {
            Node<T> n = head_;
            int i = 0;
            for (; n != null; ++i)
                n = n.Next;

            delete(i - 1);
        }
        
        public void popFront()
        {
            delete(0);
        }

        public void pushFront(T elt)
        {
            insert(0, elt);
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