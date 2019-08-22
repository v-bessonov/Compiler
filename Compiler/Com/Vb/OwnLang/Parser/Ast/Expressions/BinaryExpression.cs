using System.Text;
using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;
using Compiler.Com.Vb.OwnLang.Lib.Values;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Expressions
{
    public class BinaryExpression : IExpression
    {
        public readonly IExpression _expr1;
        public readonly IExpression _expr2;
        private readonly char _operation;

        public BinaryExpression(char operation, IExpression expr1, IExpression expr2)
        {
            _operation = operation;
            _expr1 = expr1;
            _expr2 = expr2;
        }


        //public double Eval()
        //{
        //    switch (_operation)
        //    {
        //        case '-': return _expr1.Eval() - _expr2.Eval();
        //        case '*': return _expr1.Eval() * _expr2.Eval();
        //        case '/': return _expr1.Eval() / _expr2.Eval();
        //        case '+':
        //        default:
        //            return _expr1.Eval() + _expr2.Eval();
        //    }
        //}

        public IValue Eval()
        {
            var value1 = _expr1.Eval();
            var value2 = _expr2.Eval();
            if (value1 is StringValue || value1 is ArrayValue)
            {
                string string1 = value1.AsString();
                switch (_operation)
                {
                    case '*':
                        {
                            var iterations = (int)value2.AsNumber();
                            var buffer = new StringBuilder();
                            for (var i = 0; i < iterations; i++)
                            {
                                buffer.Append(string1);
                            }
                            return new StringValue(buffer.ToString());
                        }
                    case '+':
                    default:
                        return new StringValue(string1 + value2.AsString());
                }
            }
            var number1 = value1.AsNumber();
            var number2 = value2.AsNumber();
            switch (_operation)
            {
                case '-': return new NumberValue(number1 - number2);
                case '*': return new NumberValue(number1 * number2);
                case '/': return new NumberValue(number1 / number2);
                case '+':
                default:
                    return new NumberValue(number1 + number2);
            }
        }



        public void Accept(IVisitor visitor) => visitor.Visit(this);

        public override string ToString() => $"[{_expr1} {_operation} {_expr2}]";
    }
}
