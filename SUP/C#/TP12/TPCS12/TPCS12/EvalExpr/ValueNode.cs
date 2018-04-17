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
        }
        
        public void Print()
        {
            Console.Write(_val);
        }

        public void PrintRevertPolish()
        {
            Console.Write(_val);
            Console.Write(" ");
        }

        public int Eval()
        {
            return _val;
        }
    }
}