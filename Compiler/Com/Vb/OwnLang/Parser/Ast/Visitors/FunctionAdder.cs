using Compiler.Com.Vb.OwnLang.Parser.Ast.Statements;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Visitors
{
    public class FunctionAdder : AbstractVisitor
    {
        public override void Visit(FunctionDefineStatement s)
        {
            base.Visit(s);
            s.Execute();
        }
    }
}
