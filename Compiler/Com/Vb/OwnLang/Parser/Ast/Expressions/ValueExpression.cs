using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Expressions
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

        public void Accept(IVisitor visitor) => visitor.Visit(this);

        public override string ToString() => _value.AsString();
    }
}
