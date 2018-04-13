using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace EvalExpr
{
    public class UnaryNode : INode
    {
        private bool _positive;
        private INode _val;

        public UnaryNode(bool positive)
        {
            _positive = positive;
            _val = null;
        }

        public void Build(Stack<INode> output)
        {
            //FIXME
            throw new NotImplementedException();
        }

        public void Print()
        {
            //FIXME
            throw new NotImplementedException();
        }
        
        public void PrintRevertPolish()
        {
            //FIXME
            throw new NotImplementedException();
        }

        public int Eval()
        {
            //FIXME
            throw new NotImplementedException();
        }
    }
}