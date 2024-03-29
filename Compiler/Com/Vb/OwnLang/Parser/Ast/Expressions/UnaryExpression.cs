﻿using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Expressions
{
    public class UnaryExpression : IExpression
    {
        public readonly IExpression _expr1;
        private readonly char _operation;

        public UnaryExpression(char operation, IExpression expr1)
        {
            _operation = operation;
            _expr1 = expr1;
        }

        //public double Eval()
        //{
        //    switch (_operation)
        //    {
        //        case '-': return -_expr1.Eval();
        //        case '+':
        //        default:
        //            return _expr1.Eval();
        //    }
        //}
        public IValue Eval()
        {
            switch (_operation)
            {
                case '-': return new NumberValue(-_expr1.Eval().AsNumber());
                case '+':
                default:
                    return _expr1.Eval();
            }
        }
        public void Accept(IVisitor visitor) => visitor.Visit(this);
        public override string ToString() => $"{_operation} {_expr1}";
    }
}
