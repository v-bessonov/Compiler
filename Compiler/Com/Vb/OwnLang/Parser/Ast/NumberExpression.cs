using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class NumberExpression : IExpression
    {
        //private readonly double _value;
        private readonly IValue _value;

        //public NumberExpression(double value)
        //{
        //    _value = value;
        //}
        public NumberExpression(double value)
        {
            _value = new NumberValue(value);
        }


        //public double Eval()
        //{
        //    return _value;
        //}
        public IValue Eval()
        {
            return _value;
        }

        //public override string ToString() => _value.ToString(CultureInfo.CurrentCulture);
        public override string ToString() => _value.AsString();
    }
}
