using Compiler.Com.Vb.OwnLang.Lib;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces
{
    public interface IExpression
    {
        //double Eval();
        IValue Eval();
    }
}
