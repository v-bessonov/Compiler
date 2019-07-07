using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class AssignmentStatement : IStatement
    {
        private readonly string _variable;
        private readonly IExpression _expression;

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

        public override string ToString() => $"{_variable} = {_expression}";
    }
}
