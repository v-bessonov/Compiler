using System;
using System.Text;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class IfStatement : IStatement
    {
        private readonly IExpression _expression;
        private readonly IStatement _ifStatement;
        private readonly IStatement _elseStatement;

        public IfStatement(IExpression expression, IStatement ifStatement, IStatement elseStatement)
        {
            _expression = expression;
            _ifStatement = ifStatement;
            _elseStatement = elseStatement;
        }

        public void Execute()
        {
            var result = _expression.Eval().AsNumber();
            if (Math.Abs(result) > 0.01)
            {
                _ifStatement.Execute();
            }
            else
            {
                _elseStatement?.Execute();
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("if ").Append(_expression).Append(' ').Append(_ifStatement);
            if (_elseStatement != null)
            {
                result.Append($"{Environment.NewLine}else ").Append(_elseStatement);
            }
            return result.ToString();
        }
    }
}
