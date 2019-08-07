using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces
{
    public interface IExpression
    {
        //double Eval();
        IValue Eval();
    }
}
