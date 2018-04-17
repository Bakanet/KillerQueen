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
            _val = output.Pop();
            _val.Build(output);
        }

        public void Print(){
            if (!_positive)
                Console.Write("-");
            _val.Print();
        }
        
        public void PrintRevertPolish()
        {
            //FIXME
            throw new NotImplementedException();
        }

        public int Eval()
        {
            int sign = 1;
            if (!_positive)
                sign = -1;

            return sign * _val.Eval();
        }}
}