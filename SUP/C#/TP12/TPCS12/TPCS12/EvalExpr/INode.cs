using System.Collections.Generic;

namespace EvalExpr
{
    public interface INode
    {
        void Build(Stack<INode> output);
        void Print();
        void PrintRevertPolish();
        int Eval();
    }
}