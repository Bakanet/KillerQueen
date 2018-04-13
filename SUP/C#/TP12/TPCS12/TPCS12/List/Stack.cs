using System;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace List
{
    public class Stack<T> : List<T>
    {
        public Stack()
            : base()
        {}
        
        public Stack(T elt)
            : base(elt)
        {}
        
        public T front()
        {
            if (head_ == null)
                throw new NullReferenceException("stack is empty");

            return head_.Data;
        }
        
        public void popFront()
        {
            delete(0);
        }
        
        public void pushFront(T elt)
        {
            insert(0, elt);
        }
    }
}