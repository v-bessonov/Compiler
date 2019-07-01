using System;
using System.Collections.Generic;
using Compiler.Com.Vb.OwnLang.Parser;
using Compiler.Com.Vb.OwnLang.Parser.Ast;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            //const string input1 = "2 + 2";
            const string input2 = "(2 + 2) * #f";
            const string input3 = "(GOLDEN_RATIO + 2) * #f";
            const string input4 = "GOLDEN_RATIO";
            var tokens = new Lexer(input3).Tokenize();
            foreach (var token in tokens)
            {
                Console.WriteLine(token);
            }

            var expressions = new Parser(tokens).Parse();
            foreach (var expr in expressions)
            {
                Console.WriteLine($"{expr} = {expr.Eval()}");
            }
            Console.ReadLine();
        }
    }
}
