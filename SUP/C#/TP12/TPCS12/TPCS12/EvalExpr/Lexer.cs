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
                ++pos;
                return new Token(Token.Type.INT, expr[pos].ToString());
            }
            switch (expr[pos])
            {
                case '+':
                    ++pos;
                    return new Token(Token.Type.PLUS, null);
                case '-':
                    ++pos;
                    return new Token(Token.Type.MINUS, null);
                case '*':
                    ++pos;
                    return new Token(Token.Type.MULT, null);
                case '/':
                    ++pos;
                    return new Token(Token.Type.DIV, null);
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