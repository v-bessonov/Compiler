using System;
using System.Text;
using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class ConditionalExpression : IExpression
    {
        private readonly IExpression _expr1;
        private readonly IExpression _expr2;
        private readonly char _operation;

        public ConditionalExpression(char operation, IExpression expr1, IExpression expr2)
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
            if (value1 is StringValue)
            {
                var string1 = value1.AsString();
                var string2 = value1.AsString();
                

                switch (_operation)
                {
                    case '<': return new NumberValue(string.Compare(string1, string2, StringComparison.Ordinal) < 0);
                    case '>': return new NumberValue(string.Compare(string1, string2, StringComparison.Ordinal) > 0);
                    case '=':
                    default:
                        return new NumberValue(string1 ==string2);
                }
            }
            var number1 = value1.AsNumber();
            var number2 = value1.AsNumber();
            switch (_operation)
            {
                case '<': return new NumberValue(number1 < number2);
                case '>': return new NumberValue(number1 > number2);
                case '=':
                default:
                    return new NumberValue(Math.Abs(number1 - number2) < 0.01);
            }
        }




        public override string ToString() => $"[{_expr1} {_operation} {_expr2}]";
    }
}
