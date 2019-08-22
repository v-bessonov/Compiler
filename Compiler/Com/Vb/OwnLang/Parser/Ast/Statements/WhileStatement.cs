using System;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Statements
{
    public class WhileStatement : IStatement
    {
        public readonly IExpression _condition;
        public readonly IStatement _statement;

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

        public void Accept(IVisitor visitor) => visitor.Visit(this);

        public override string ToString()
        {
            return $"while {_condition} {_statement}";
        }
    }
}
