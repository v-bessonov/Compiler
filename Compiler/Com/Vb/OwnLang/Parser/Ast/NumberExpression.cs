using System.Globalization;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class NumberExpression : IExpression
    {
        private readonly double _value;

        public NumberExpression(double value)
        {
            _value = value;
        }

        
        public double Eval()
        {
            return _value;
        }

        public override string ToString() => _value.ToString(CultureInfo.CurrentCulture);
    }
}
