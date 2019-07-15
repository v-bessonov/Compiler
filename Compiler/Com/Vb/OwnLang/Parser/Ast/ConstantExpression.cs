using System;
using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class ConstantExpression : IExpression
    {
        private readonly string _name;
    
        public ConstantExpression(String name)
        {
            _name = name;
        }

        //public double Eval()
        //{
        //    if (!Constants.IsExists(_name)) throw new Exception("Constant does not exists");
        //    return Constants.Get(_name);
        //}

        //public double Eval()
        //{
        //    if (!Constants.IsExists(_name)) throw new Exception("Constant does not exists");
        //    return Constants.Get(_name);
        //}

        public IValue Eval()
        {
            if (!Constants.IsExists(_name)) throw new Exception("Constant does not exists");
            return Constants.Get(_name);
        }

        public override string ToString() => $"{_name}";
    }
}
