using Compiler.Com.Vb.OwnLang.Parser.Ast.Expressions;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Statements
{
    public class ArrayAssignmentStatement : IStatement
    {
        public readonly ArrayAccessExpression _array;
        public readonly IExpression _expression;

        public ArrayAssignmentStatement(ArrayAccessExpression array, IExpression expression)
        {
            _array = array;
            _expression = expression;
        }

        
        public void Execute()
        {
            _array.GetArray().Set(_array.LastIndex(), _expression.Eval());
        }

        public void Accept(IVisitor visitor) => visitor.Visit(this);


        public override string ToString()
        {
            return $"{_array} = {_expression}";
        }
    }
}
