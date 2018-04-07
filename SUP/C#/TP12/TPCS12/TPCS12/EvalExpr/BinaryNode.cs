using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace EvalExpr
{
    public class BinaryNode : INode
    {
        public enum Operator
        {
            PLUS,
            MINUS,
            MULT,
            DIV
        };

        private Operator _op;
        private INode _left;
        private INode _right;

        public Operator Op
        {
            get { return _op; }
        }

        public BinaryNode(Operator op)
        {
            _op = op;
            _left = null;
            _right = null;
        }

        public void Build(Stack<INode> output)
        {
            _right = output.Pop();
            _right.Build(output);
            _left = output.Pop();
            _left.Build(output);
        }
 
        public void Print()
        {
            Console.Write('(');
            _left.Print();
            Console.Write(_op);
            _right.Print();
            Console.Write(')');
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