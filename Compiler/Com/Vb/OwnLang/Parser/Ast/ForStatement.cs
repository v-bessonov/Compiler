using System;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class ForStatement : IStatement
    {
        private readonly IStatement _init;
        private readonly IExpression _termination;
        private readonly IStatement _increment;
        private readonly IStatement _statement;

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
                _statement.Execute();
            }
        }

        public override string ToString()
        {
            return $"for {_init}, {_termination}, {_increment} {_statement}";
        }
    }
}
