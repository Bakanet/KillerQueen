using System;
using System.Collections.Generic;
using System.Data;

namespace EvalExpr
{
    public static class Parser
    {
        public static INode Parse(string expr)
        {
            List<Token> tokens = Lexer.Lex(expr);
            Stack<INode> output = new Stack<INode>();
            Stack<Token> operatorStack = new Stack<Token>();
            int[] priority = { 1, 1, 2, 2 };    // priorites des operateurs + - * / (on utilise leur place dans l'enum pour recuperer leur priorite dans le tableau)

            foreach (var token in tokens)
            {
                if (token.TokType == Token.Type.INT)
                {
                    output.Push(new ValueNode(int.Parse(token.Val)));
                }

                else
                {
                    while (operatorStack.Count != 0 && priority[(int)operatorStack.Peek().TokType] >= priority[(int)token.TokType])
                        output.Push(new BinaryNode((BinaryNode.Operator)(int)operatorStack.Pop().TokType));
                    // c'est archi lourd mais en gros on prend le 1er op de la stack des operators et on crée un INode qu'on push dans notre output

                    operatorStack.Push(token);
                }
            }

            while (operatorStack.Count != 0)
                output.Push(new BinaryNode((BinaryNode.Operator)(int)operatorStack.Pop().TokType));

            INode root = output.Pop();
            root.Build(output);

            return root;
        }
    }
}