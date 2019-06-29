namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class BinaryExpression : IExpression
    {
        private readonly IExpression _expr1;
        private readonly IExpression _expr2;
        private readonly char _operation;

        public BinaryExpression(char operation, IExpression expr1, IExpression expr2)
        {
            _operation = operation;
            _expr1 = expr1;
            _expr2 = expr2;
        }

        
        public double Eval()
        {
            switch (_operation)
            {
                case '-': return _expr1.Eval() - _expr2.Eval();
                case '*': return _expr1.Eval() * _expr2.Eval();
                case '/': return _expr1.Eval() / _expr2.Eval();
                case '+':
                default:
                    return _expr1.Eval() + _expr2.Eval();
            }
        }


        public override string ToString() => $"{_expr1} {_operation} {_expr2}";
    }
}
