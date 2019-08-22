using System;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Statements
{
    public class ContinueStatement : Exception, IStatement
    {
        public void Execute()
        {
            throw this;
        }
        public void Accept(IVisitor visitor) => visitor.Visit(this);
        public override string ToString()
        {
            return "continue";
        }
    }
}
