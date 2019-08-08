using System;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class ReturnStatement : Exception, IStatement
    {
        private readonly IExpression _expression;
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
        public override string ToString()
        {
            return "return";
        }

    }
}
