using System;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Statements
{
    public class DoWhileStatement : IStatement
    {
        public readonly IExpression _condition;
        public readonly IStatement _statement;

        public DoWhileStatement(IExpression condition, IStatement statement)
        {
            _condition = condition;
            _statement = statement;
        }


        public void Execute()
        {
            do
            {
                try
                {
                    _statement.Execute();
                }
                catch (BreakStatement bs)
                {
                    break;
                }
                catch (ContinueStatement cs)
                {
                    continue;
                }
            }
            while (Math.Abs(_condition.Eval().AsNumber()) > 0.01);
        }

        public void Accept(IVisitor visitor) => visitor.Visit(this);

        public override string ToString()
        {
            return $"do {_statement} while {_condition}";
        }
    }
}
