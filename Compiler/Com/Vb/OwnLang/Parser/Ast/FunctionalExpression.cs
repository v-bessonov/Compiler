using System;
using System.Collections.Generic;
using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class FunctionalExpression : IExpression
    {
        private readonly string _name;
        private readonly List<IExpression> _arguments;

        public FunctionalExpression(string name)
        {
            _name = name;
            _arguments = new List<IExpression>();
        }

        public FunctionalExpression(string name, List<IExpression> arguments)
        {
            _name = name;
            _arguments = arguments;
        }

        public void AddArgument(IExpression arg)
        {
            _arguments.Add(arg);
        }

        public IValue Eval()
        {
            var size = _arguments.Count;
            var values = new IValue[size];
            for (var i = 0; i < size; i++)
            {
                values[i] = _arguments[i].Eval();
            }


            var function = Functions.Get(_name);
            if (function is UserDefinedFunction userFunction) {
                if (size != userFunction.GetArgsCount()) throw new Exception("Args count mismatch");

                Variables.Push();
                for (int i = 0; i < size; i++)
                {
                    Variables.Set(userFunction.GetArgsName(i), values[i]);
                }
                IValue result = userFunction.Execute(values);
                Variables.Pop();
                return result;
            }
            return function.Execute(values);
        }

        public override string ToString()
        {
            return $"{_name}({_arguments})";
        }
    }
}
