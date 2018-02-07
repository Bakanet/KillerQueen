using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Brainfuck
{
    class Program
    {
        [STAThread]
        /**
         * Used in IDE.cs in order to give the resulting Dictionnary as argument to
         * the button handlers.
         */
        public static Dictionary<char, char> classicBrainfuck()
        {
            Dictionary<char, char> brainfuck = new Dictionary<char, char>();
            brainfuck.Add('>', '>');
            brainfuck.Add('<', '<');
            brainfuck.Add('+', '+');
            brainfuck.Add('-', '-');
            brainfuck.Add('.', '.');
            brainfuck.Add(',', ',');
            brainfuck.Add('[', '[');
            brainfuck.Add(']', ']');
            
            return brainfuck;
        }
        
        public static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IDE());
        }

        
    }
}
