using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class ValueExpression : IExpression
    {
        private readonly IValue _value;
    
        public ValueExpression(double value)
        {
            _value = new NumberValue(value);
        }

        public ValueExpression(string value)
        {
            _value = new StringValue(value);
        }
        
        public IValue Eval()
        {
            return _value;
        }


        public override string ToString() => _value.AsString();
    }
}
