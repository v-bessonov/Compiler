namespace Compiler.Com.Vb.OwnLang.Lib.Interfaces
{
    public interface IFunction
    {
        IValue Execute(params IValue[] args);
    }
}
