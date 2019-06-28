using System;
using System.Collections.Generic;
using Compiler.Com.Vb.OwnLang.Parser.Ast;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            const string input1 = "2 + 2";
            const string input2 = "(2 + 2) * #f";
            var tokens = new Lexer(input2).Tokenize();
            foreach (var token in tokens)
            {
                Console.WriteLine(token);
            }

            Console.ReadLine();
        }
    }
}
