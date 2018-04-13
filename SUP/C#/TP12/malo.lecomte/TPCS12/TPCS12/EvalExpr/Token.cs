using System;
using System.Runtime.Remoting.Messaging;

namespace EvalExpr
{
    public class Token
    {
        public enum Type
        {
            PLUS,
            MINUS,
            MULT,
            DIV,
            INT
        }

        private Type _toktype;
        private string _val;

        public Type TokType
        {
            get { return _toktype; }
        }
        
        public string Val
        {
            get { return _val; }
        }

        public Token(Type toktype, string val)
        {
            _val = val;
            _toktype = toktype;
        }

        public override string ToString()
        {
            return _val;
        }
    }
}