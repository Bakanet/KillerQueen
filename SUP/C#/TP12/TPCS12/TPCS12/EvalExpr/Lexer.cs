using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace EvalExpr
{
    public static class Lexer
    {

        public static Token Tokenize(ref int pos, string expr)
        {
            if (expr[pos] > '0' && expr[pos] < '9')
            {
                string str = "";
                while (pos < expr.Length && expr[pos] > '0' && expr[pos] < '9')
                {
                    str += expr[pos];
                    ++pos;
                }

                return new Token(Token.Type.INT, str);
            }
            switch (expr[pos])
            {
                case '+':
                    ++pos;
                    return new Token(Token.Type.PLUS, "+");
                case '-':
                    ++pos;
                    return new Token(Token.Type.MINUS, "-");
                case '*':
                    ++pos;
                    return new Token(Token.Type.MULT, "*");
                case '/':
                    ++pos;
                    return new Token(Token.Type.DIV, "/");
                default:
                    throw new ArgumentException("char isn't an int or an operator");
            }
        }
        
        public static List<Token> Lex(string expr)
        {
            List<Token> list = new List<Token>();
            for (int i = 0; i < expr.Length;)
            {
                if (expr[i] == ' ')
                {
                    ++i;
                    continue;
                }

                list.Add(Tokenize(ref i, expr));
            }

            return list;
        }
    }
}