using Compiler.Com.Vb.OwnLang.Lib.Interfaces;
using Compiler.Com.Vb.OwnLang.Lib.Values;

namespace Compiler.Com.Vb.OwnLang.Lib.Funcs
{
    public class NewArrayFunction : IFunction
    {
        private static NumberValue ZERO = new NumberValue(0);
        public IValue Execute(params IValue[] args)
        {
            return CreateArray(args, 0);
        }

        private ArrayValue CreateArray(IValue[] args, int index)
        {
            var size = (int)args[index].AsNumber();
            var last = args.Length - 1;
            var array = new ArrayValue(size);
            if (index == last)
            {
                for (var i = 0; i < size; i++)
                {
                    array.Set(i, NumberValue.ZERO);
                }
            }
            else if (index < last)
            {
                for (int i = 0; i < size; i++)
                {
                    array.Set(i, CreateArray(args, index + 1));
                }
            }
            return array;
        }
    }
}
