using System;
using System.Linq;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Lib.Values
{
    public class ArrayValue : IValue
    {
        private readonly IValue[] _elements;

        public ArrayValue(int size)
        {
            this._elements = new IValue[size];
        }

        public ArrayValue(IValue[] elements)
        {
            _elements = new IValue[elements.Length];
            Array.Copy(elements,0,this._elements,0,elements.Length);
        }

        public ArrayValue(ArrayValue array) : this(array._elements)
        {
        }

        public IValue Get(int index)
        {
            return _elements[index];
        }

        public void Set(int index, IValue value)
        {
            _elements[index] = value;
        }

        public double AsNumber()
        {
            throw new Exception("Cannot cast array to number");
        }

        public string AsString()
        {
            return $"[{string.Join(",", _elements.Select(e => e.AsString()))}]";
        }

        public override string ToString()
        {
            return AsString();
        }
    }
}
