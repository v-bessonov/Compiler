using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public interface IExpression
    {
        double Eval();
    }
}
