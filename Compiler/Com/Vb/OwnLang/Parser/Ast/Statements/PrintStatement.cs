using System;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Statements
{
    public class PrintStatement : IStatement
    {
        public readonly IExpression _expression;

        public PrintStatement(IExpression expression)
        {
            _expression = expression;
        }

        public void Execute()
        {
            Console.Write(_expression.Eval());
        }

        public void Accept(IVisitor visitor) => visitor.Visit(this);

        public override string ToString() => $"print {_expression}";
    }
}
