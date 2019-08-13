using System;
using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;
using Compiler.Com.Vb.OwnLang.Lib.Values;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Expressions
{
    public class ArrayAccessExpression : IExpression
    {
        private readonly string _variable;
        private readonly IExpression _index;

        public ArrayAccessExpression(string variable, IExpression index)
        {
            _variable = variable;
            _index = index;
        }

        public IValue Eval()
        {
            var var = Variables.Get(_variable);
            if (var is ArrayValue array) {
                return array.Get((int)_index.Eval().AsNumber());
            }

            throw new Exception("Array expected");
        }

        public override string ToString()
        {
            return $"{_variable}[{_index}]";
        }
    }
}
