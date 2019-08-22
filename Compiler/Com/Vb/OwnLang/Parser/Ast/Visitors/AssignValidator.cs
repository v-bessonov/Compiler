using System;
using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Statements;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Visitors
{
    public  class AssignValidator : AbstractVisitor
    {

    public override void Visit(AssignmentStatement s)
    {
        base.Visit(s);
        if (Variables.IsExists(s._variable))
        {
            throw new Exception("Cannot assign value to constant");
        }
    }
    }
}
