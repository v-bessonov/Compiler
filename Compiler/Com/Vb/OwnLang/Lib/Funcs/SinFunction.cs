using System;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Lib.Funcs
{
    public class SinFunction : IFunction
    {
        public IValue Execute(params IValue[] args)
        {
            if (args.Length != 1) throw new Exception("One arg expected");
            return new NumberValue(Math.Sin(args[0].AsNumber()));

        }
    }
}
