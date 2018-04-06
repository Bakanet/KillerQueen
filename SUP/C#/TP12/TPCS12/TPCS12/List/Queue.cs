using System;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace List
{
    public class Queue<T> //FIXME 
    {
        public Queue()
            : base()
        {}
        
        public Queue(T elt)
            : base() //FIXME
        {}
        
        public T front()
        {
            //FIXME
            throw new NotImplementedException();
        }
        
        public void popFront()
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