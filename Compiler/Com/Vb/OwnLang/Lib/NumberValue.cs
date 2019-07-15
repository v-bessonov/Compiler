using System.Globalization;

namespace Compiler.Com.Vb.OwnLang.Lib
{
    public class NumberValue : IValue
    {
        private readonly double _value;

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
