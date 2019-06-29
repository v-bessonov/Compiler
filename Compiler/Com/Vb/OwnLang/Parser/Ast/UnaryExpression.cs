namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class UnaryExpression : IExpression
    {
        private readonly IExpression _expr1;
        private readonly char _operation;

        public UnaryExpression(char operation, IExpression expr1)
        {
            _operation = operation;
            _expr1 = expr1;
        }

        public double Eval()
        {
            switch (_operation)
            {
                case '-': return -_expr1.Eval();
                case '+':
                default:
                    return _expr1.Eval();
            }
        }

        public override string ToString() => $"{_operation} {_expr1}";
    }
}
