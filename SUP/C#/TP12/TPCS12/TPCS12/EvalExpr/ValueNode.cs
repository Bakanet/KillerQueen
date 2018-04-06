using System;
using System.Collections.Generic;

namespace EvalExpr
{
    public class ValueNode : INode
    {
        private int _val;

        public ValueNode(int val)
        {
            _val = val;
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