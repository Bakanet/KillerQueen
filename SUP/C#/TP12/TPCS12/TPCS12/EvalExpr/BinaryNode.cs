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
            //FIXME
            throw new NotImplementedException();
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