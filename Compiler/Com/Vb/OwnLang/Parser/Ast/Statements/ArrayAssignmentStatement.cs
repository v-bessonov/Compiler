using Compiler.Com.Vb.OwnLang.Parser.Ast.Expressions;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Statements
{
    public class ArrayAssignmentStatement : IStatement
    {
        private readonly ArrayAccessExpression _array;
        private readonly IExpression _expression;

        public ArrayAssignmentStatement(ArrayAccessExpression array, IExpression expression)
        {
            _array = array;
            _expression = expression;
        }

        
        public void Execute()
        {
            _array.GetArray().Set(_array.LastIndex(), _expression.Eval());
        }

        
        public override string ToString()
        {
            return $"{_array} = {_expression}";
        }
    }
}
