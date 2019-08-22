using System;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Statements
{
    public class ReturnStatement : Exception, IStatement
    {
        public readonly IExpression _expression;
        private IValue _result;

        public ReturnStatement(IExpression expression)
        {
            _expression = expression;
        }

        public IValue GetResult()
        {
            return _result;
        }

        public void Execute()
        {
            _result = _expression.Eval();
            throw this;
        }
        public void Accept(IVisitor visitor) => visitor.Visit(this);

        public override string ToString()
        {
            return "return";
        }

    }
}
