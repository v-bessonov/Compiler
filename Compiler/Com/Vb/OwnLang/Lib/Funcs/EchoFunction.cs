using System;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Lib.Funcs
{
    public class EchoFunction : IFunction
    {
        private static NumberValue ZERO = new NumberValue(0);
        public IValue Execute(params IValue[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine(arg.AsString());
            }
            return ZERO;
        }
    }
}
