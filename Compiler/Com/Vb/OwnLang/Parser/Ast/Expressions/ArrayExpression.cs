using System.Collections.Generic;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;
using Compiler.Com.Vb.OwnLang.Lib.Values;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Expressions
{
    public class ArrayExpression : IExpression
    {
        private readonly List<IExpression> _elements;

        public ArrayExpression(List<IExpression> arguments)
        {
            _elements = arguments;
        }

        public IValue Eval()
        {
            var size = _elements.Count;
            var array = new ArrayValue(size);
            for (var i = 0; i < size; i++)
            {
                array.Set(i, _elements[i].Eval());
            }
            return array;
        }

        public override string ToString()
        {
            return _elements.ToString();
        }
    }
}
