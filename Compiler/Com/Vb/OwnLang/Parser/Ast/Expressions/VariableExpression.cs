using System;
using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Expressions
{
    public class VariableExpression : IExpression
    {
        public readonly string _name;
    
        public VariableExpression(String name)
        {
            _name = name;
        }

        //public double Eval()
        //{
        //    if (!Variables.IsExists(_name)) throw new Exception("Constant does not exists");
        //    return Variables.Get(_name);
        //}

        public IValue Eval()
        {
            if (!Variables.IsExists(_name)) throw new Exception("Constant does not exists");
            return Variables.Get(_name);
        }
        public void Accept(IVisitor visitor) => visitor.Visit(this);
        public  override string ToString()
        {
            return $"{_name}";
        }
    }
}
