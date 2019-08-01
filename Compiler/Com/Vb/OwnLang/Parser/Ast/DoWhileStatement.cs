using System;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class DoWhileStatement : IStatement
    {
        private readonly IExpression _condition;
        private readonly IStatement _statement;

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


        public override string ToString()
        {
            return $"do {_statement} while {_condition}";
        }
    }
}
