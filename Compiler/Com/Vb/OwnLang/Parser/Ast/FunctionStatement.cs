using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class FunctionStatement : IStatement
    {
        private readonly FunctionalExpression _function;
    
        public FunctionStatement(FunctionalExpression function)
        {
            _function = function;
        }
        
        public void Execute()
        {
            _function.Eval();
        }
        
        public override string ToString()
        {
            return _function.ToString();
        }
    }
}
