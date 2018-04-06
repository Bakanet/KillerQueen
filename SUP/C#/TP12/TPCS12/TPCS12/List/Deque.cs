using System;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace List
{
    public class Dequeue<T> //FIXME
    {
        public Dequeue()
            : base()
        {}
        
        public Dequeue(T elt)
            : base() //FIXME
        {}
        
        public T front()
        {
            //FIXME
            throw new NotImplementedException();
        }
        
        public T back()
        {
            //FIXME
            throw new NotImplementedException();
        }
        
        public virtual void popBack()
        {
            //FIXME
            throw new NotImplementedException();
        }
        
        public void popFront()
        {
            //FIXME
            throw new NotImplementedException();
        }

        public void pushFront(T elt)
        {
            //FIXME
            throw new NotImplementedException();
        }
        
        public void pushBack(T elt)
        {
            //FIXME
            throw new NotImplementedException();
        }
    }
}