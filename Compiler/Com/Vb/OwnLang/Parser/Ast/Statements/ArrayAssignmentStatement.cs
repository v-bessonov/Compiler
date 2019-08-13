using System;
using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Lib.Values;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Statements
{
    public class ArrayAssignmentStatement :IStatement
    {
        private readonly string _variable;
        private readonly IExpression _index;
        private readonly IExpression _expression;

        public ArrayAssignmentStatement(string variable, IExpression index, IExpression expression)
        {
            _variable = variable;
            _index = index;
            _expression = expression;
        }

        public void Execute()
        {
            var var = Variables.Get(_variable);
            if (var is ArrayValue array) {
                array.Set((int)_index.Eval().AsNumber(), _expression.Eval());
            } else {
                throw new Exception("Array expected");
            }
        }

        public override string ToString()
        {
            return $"{_variable}[{_index}] = {_expression}";
        }
    }
}
