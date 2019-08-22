using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Statements
{
    public class AssignmentStatement : IStatement
    {
        public readonly string _variable;
        public readonly IExpression _expression;

        public AssignmentStatement(string variable, IExpression expression)
        {
            _variable = variable;
            _expression = expression;
        }

        public void Execute()
        {
            var result = _expression.Eval();
            Variables.Set(_variable, result);
        }

        public void Accept(IVisitor visitor) => visitor.Visit(this);

        public override string ToString() => $"{_variable} = {_expression}";
    }
}
