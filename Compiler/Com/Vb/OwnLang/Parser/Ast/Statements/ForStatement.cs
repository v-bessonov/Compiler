using System;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Statements
{
    public class ForStatement : IStatement
    {
        public readonly IStatement _init;
        public readonly IExpression _termination;
        public readonly IStatement _increment;
        public readonly IStatement _statement;

        public ForStatement(IStatement init, IExpression termination, IStatement increment, IStatement block)
        {
            _init = init;
            _termination = termination;
            _increment = increment;
            _statement = block;
        }

        public void Execute()
        {
            for (_init.Execute(); Math.Abs(_termination.Eval().AsNumber()) > 0.01; _increment.Execute())
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
            return $"for {_init}, {_termination}, {_increment} {_statement}";
        }
    }
}
