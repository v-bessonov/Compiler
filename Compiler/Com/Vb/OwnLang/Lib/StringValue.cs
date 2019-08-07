using Compiler.Com.Vb.OwnLang.Lib.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Lib
{
    public class StringValue : IValue
    {
        private readonly string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public double AsNumber()
        {
            var success = double.TryParse(_value, out var number);
            return success ? number : 0;
        }

        public string AsString()
        {
            return _value;
        }

        public override string ToString()
        {
            return AsString();
        }
    }
}
