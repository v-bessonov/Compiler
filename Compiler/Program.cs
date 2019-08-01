using System;
using System.Collections.Generic;
using System.IO;
using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Parser;
using Compiler.Com.Vb.OwnLang.Parser.Ast;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            //const string input1 = "2 + 2";
            //const string input2 = "(2 + 2) * #f";
            //const string input3 = "(GOLDEN_RATIO + 2) * #f";
            //const string input4 = "GOLDEN_RATIO";
            //const string input5 = "word = 2 + 2\nword2 = PI + word\nprint word";
            var input5 = File.ReadAllText("program.txt");
            var tokens = new Lexer(input5).Tokenize();
            
            foreach (var token in tokens)
            {
                Console.WriteLine(token);
            }

            //var expressions = new Parser(tokens).Parse();
            //foreach (var expr in expressions)
            //{
            //    Console.WriteLine($"{expr} = {expr.Eval()}");
            //}

            //var statements = new Parser(tokens).Parse();
            //foreach (var statement in statements)
            //{
            //    Console.WriteLine(statement);
            //}
            //foreach (var statement in statements)
            //{s
            //    statement.Execute();
            //}

            var program = new Parser(tokens).Parse();
            Console.WriteLine(program.ToString());
            program.Execute();


            //Console.WriteLine($"word = {Variables.Get("word")}");
            //Console.WriteLine($"word2 = {Variables.Get("word2")}");
            Console.ReadLine();
        }
    }
}
