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
            
            switch (_op)
            {
                case Operator.PLUS:
                    Console.Write(" + ");
                    break;
                case Operator.MINUS:
                    Console.Write(" - ");
                    break;
                case Operator.MULT:
                    Console.Write(" * ");
                    break;
                case Operator.DIV:
                    Console.Write(" / ");
                    break;
            }

            _right.Print();
            Console.Write(')');
        }

        public void PrintRevertPolish()
        {
            _left.PrintRevertPolish();
            _right.PrintRevertPolish();

            switch (_op)
            {
                case Operator.PLUS:
                    Console.Write("+ ");
                    break;
                case Operator.MINUS:
                    Console.Write("- ");
                    break;
                case Operator.MULT:
                    Console.Write("* ");
                    break;
                case Operator.DIV:
                    Console.Write("/ ");
                    break;
            }
        }
        
        public int Eval()
        {
            switch (_op)
            {
                case Operator.PLUS:
                    return _left.Eval() + _right.Eval();

                case Operator.MINUS:
                    return _left.Eval() - _right.Eval();

                case Operator.MULT:
                    return _left.Eval() * _right.Eval();

                default:
                    return _left.Eval() / _right.Eval();
            }
        }
    }
}