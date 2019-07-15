using System;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class PrintStatement : IStatement
    {
        private readonly IExpression _expression;

        public PrintStatement(IExpression expression)
        {
            _expression = expression;
        }

        public void Execute()
        {
            Console.Write(_expression.Eval());
        }

        public override string ToString() => $"print {_expression}";
    }
}
