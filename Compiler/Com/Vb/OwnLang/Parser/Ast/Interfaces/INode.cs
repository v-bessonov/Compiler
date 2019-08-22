namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces
{
    public interface INode
    {
         void Accept(IVisitor visitor);
    }
}
