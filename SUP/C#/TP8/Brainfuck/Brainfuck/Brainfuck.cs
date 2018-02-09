using System;
using System.Collections;
using System.Collections.Generic;

namespace Brainfuck
{   
    class Brainfuck
    {
        /**
         * Interpret @code with @symbols and return the resulting string.
         * In case of error,  an ArgumentException is raised.
         * Possible error cases are:
         *     - Invalid braces number / order
         *     - Symbol not present in @symbols
         */
        public static string Interpret(string code, Dictionary<char, char> symbols)
        {
            // Create cells array  and initialize it to 0
            // Start position pointer at the center
            // Do not forget to use a stack for the position
            // Interpret the symbols
            // Fill the resulting string

            int[] array = new int[30000];
            int i = 0;
            Stack stack = new Stack();
            string brainfucked = "";

            for (int j = 0; j < code.Length; ++j)
            {
                if (code[j] == symbols['>'])
                    ++i;

                else if (code[j] == symbols['<'])
                    --i;

                else if (code[j] == symbols['+'])
                {
                    ++array[i];
                    if (array[i] > 255)
                        array[i] = 0;
                }

                else if (code[j] == symbols['-'])
                {
                    --array[i];
                    if (array[i] < 0)
                        array[i] = 255;
                }

                else if (code[j] == symbols['.'])
                    brainfucked += (char) array[i];

                else if (code[j] == symbols[','])
                    array[i] = int.Parse(Console.ReadLine());

                else if (code[j] == symbols['['])
                {
                    stack.Push(j);
                }
                
                else if (code[j] == symbols[']'])    
                {
                    if (array[i] == 0)
                        stack.Pop();
                    else
                    {
                        j = (int) stack.Pop() - 1;
                    }
                }

                else
                    throw new ArgumentException("the code has an invalid instruction");
            }


            return brainfucked;
        }

        /**
         * Generate the brainfuck code to print @text with @symbols.and return it.
         * In case of error, an ArgumentException is raised.
         * Possible error case is:
         *     - Missing symbol in @symbols
         */
        public static string GenerateCodeFromText(string text, Dictionary<char, char> symbols)
        {
            // A naive implementation could be to generate a loop foreach character in the
            // text and the print it.

            string str = "";
            int i = 0;
            
            foreach (char character in text)
            {
                for (int j = i; j < character; ++j)
                {
                    str += "+";
                    if (j == character - 1)
                    {
                        str += ".";
                        i = j + 1;
                    }
                }

                for (int j = i; j > character; --j)
                {
                    str += "-";
                    if (j == character + 1)
                    {
                        str += ".";
                        i = j - 1;
                    }
                }
            }

            return str;
        }

        /**
        * Shorten @program with @symbols and return the resulting string.
        * In case of error, an ArgumentException is raised.
        * Possible error cases are:
        *     - Symbol not present in @symbols
        *     - Invalid symbol
        */
        public static string ShortenCode(string program, Dictionary<char, char> symbols)
        {
            // Search for the symbols['+'] sequencies and reduces it with a loop.
            // Do not hesitate to search and find more techniques.

            throw new NotImplementedException();
            return null;
        }
    }
}