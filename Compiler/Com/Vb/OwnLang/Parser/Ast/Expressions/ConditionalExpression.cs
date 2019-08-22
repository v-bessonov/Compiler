using System;
using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Operators;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Expressions
{
    public class ConditionalExpression : IExpression
    {

        public readonly IExpression _expr1;
        public readonly IExpression _expr2;
        private readonly Operator _operation;
        private const double TOLERANCE = 0.01;

        public ConditionalExpression(Operator operation, IExpression expr1, IExpression expr2)
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
            IValue value1 = _expr1.Eval();
            IValue value2 = _expr2.Eval();

            double number1, number2;
            if (value1 is StringValue) {
                number1 = string.Compare(value1.AsString(), value2.AsString(), StringComparison.Ordinal);
                number2 = 0;
            } else {
                number1 = value1.AsNumber();
                number2 = value2.AsNumber();
            }

            bool result;
            switch (_operation)
            {
                case Operator.LT: result = number1 < number2; break;
                case Operator.LTEQ: result = number1 <= number2; break;
                case Operator.GT: result = number1 > number2; break;
                case Operator.GTEQ: result = number1 >= number2; break;
                case Operator.NOT_EQUALS: result = Math.Abs(number1 - number2) > TOLERANCE; break;

                case Operator.AND: result = (Math.Abs(number1) > TOLERANCE) && (Math.Abs(number2) > TOLERANCE); break;
                case Operator.OR: result = (Math.Abs(number1) > TOLERANCE) || (Math.Abs(number2) > TOLERANCE); break;

                case Operator.EQUALS:
                default:
                    result = Math.Abs(number1 - number2) < TOLERANCE; break;
            }
            return new NumberValue(result);

            
        }


        public void Accept(IVisitor visitor) => visitor.Visit(this);

        public override string ToString() => $"[{_expr1} {_operation.GetName()} {_expr2}]";
    }
}
