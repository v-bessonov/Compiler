using System;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class BreakStatement : Exception, IStatement
    {
        public void Execute()
        {
            throw this;
        }

        public override string ToString()
        {
            return "break";
        }
    }
}
