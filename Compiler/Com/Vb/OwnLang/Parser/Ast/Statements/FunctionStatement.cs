using Compiler.Com.Vb.OwnLang.Parser.Ast.Expressions;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Statements
{
    public class FunctionStatement : IStatement
    {
        public readonly FunctionalExpression _function;
    
        public FunctionStatement(FunctionalExpression function)
        {
            _function = function;
        }
        
        public void Execute()
        {
            _function.Eval();
        }
        public void Accept(IVisitor visitor) => visitor.Visit(this);
        public override string ToString()
        {
            return _function.ToString();
        }
    }
}
