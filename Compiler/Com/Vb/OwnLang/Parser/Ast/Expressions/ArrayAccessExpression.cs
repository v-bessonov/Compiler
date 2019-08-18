using System;
using System.Collections.Generic;
using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;
using Compiler.Com.Vb.OwnLang.Lib.Values;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Expressions
{
    public class ArrayAccessExpression : IExpression
    {
        private readonly string _variable;
        private readonly List<IExpression> _indices;

        public ArrayAccessExpression(string variable, List<IExpression> indices)
        {
            _variable = variable;
            _indices = indices;
        }

        public IValue Eval()
        {
            return GetArray().Get(LastIndex());
        }

        public ArrayValue GetArray()
        {
            var array = ConsumeArray(Variables.Get(_variable));
            var last = _indices.Count - 1;
            for (var i = 0; i < last; i++)
            {
                array = ConsumeArray(array.Get(Index(i)));
            }
            return array;
        }

        public int LastIndex()
        {
            return Index(_indices.Count - 1);
        }

        private int Index(int index)
        {
            return (int)_indices[index].Eval().AsNumber();
        }

        private static ArrayValue ConsumeArray(IValue value)
        {
            if (value is ArrayValue arrayValue)
            {
                return arrayValue;
            }
            throw new Exception("Array expected");
        }

        public override string ToString() => $"{_variable}{_variable}";
    }
}
