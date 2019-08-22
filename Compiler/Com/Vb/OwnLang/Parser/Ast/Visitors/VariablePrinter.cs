using System;
using System.Collections.Generic;
using System.Text;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Expressions;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Statements;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Visitors
{

    public class VariablePrinter : AbstractVisitor
    {

        public override void Visit(ArrayAccessExpression s)
        {
            base.Visit(s);
            Console.WriteLine(s._variable);
        }

        public override void Visit(AssignmentStatement s)
        {
            base.Visit(s);
            Console.WriteLine(s._variable);
        }

        public override void Visit(VariableExpression s)
        {
            base.Visit(s);
            Console.WriteLine(s._name);
        }
    }
}
