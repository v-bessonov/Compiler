using System.Globalization;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Lib
{
    public class NumberValue : IValue
    {
        private readonly double _value;

        public NumberValue(bool value)
        {
            _value = value ? 1 : 0;
        }

        public NumberValue(double value)
        {
            _value = value;
        }

        
        public double AsNumber()
        {
            return _value;
        }

        public string AsString()
        {
            return _value.ToString(CultureInfo.InvariantCulture);
        }

        public override string ToString()
        {
            return AsString();
        }
    }
}
