using Compiler.Com.Vb.OwnLang.Lib.Interfaces;
using Compiler.Com.Vb.OwnLang.Lib.Values;

namespace Compiler.Com.Vb.OwnLang.Lib.Funcs
{
    public class NewArrayFunction : IFunction
    {
        private static NumberValue ZERO = new NumberValue(0);
        public IValue Execute(params IValue[] args)
        {
            return new ArrayValue(args);
        }
    }
}
