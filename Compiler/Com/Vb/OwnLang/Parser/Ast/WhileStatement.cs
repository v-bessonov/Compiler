using System;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class WhileStatement : IStatement
    {
        private readonly IExpression _condition;
        private readonly IStatement _statement;

        public WhileStatement(IExpression condition, IStatement statement)
        {
            _condition = condition;
            _statement = statement;
        }


        public void Execute()
        {
            while (Math.Abs(_condition.Eval().AsNumber()) > 0.01)
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
        }


        public override string ToString()
        {
            return $"while {_condition} {_statement}";
        }
    }
}
