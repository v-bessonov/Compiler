namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Operators
{

    public enum Operator
    {
        PLUS,
        MINUS,
        MULTIPLY,
        DIVIDE,
        EQUALS,
        NOT_EQUALS,
        LT,
        LTEQ,
        GT,
        GTEQ,
        AND,
        OR
    }

    public static class OperatorExtensions
    {
        public static string GetName(this Operator me)
        {
            switch (me)
            {
                case Operator.PLUS:
                    return "+";
                case Operator.MINUS:
                    return "-";
                case Operator.MULTIPLY:
                    return "*";
                case Operator.DIVIDE:
                    return "/";
                case Operator.EQUALS:
                    return "==";
                case Operator.NOT_EQUALS:
                    return "!=";
                case Operator.LT:
                    return "<";
                case Operator.LTEQ:
                    return "<=";
                case Operator.GT:
                    return ">";
                case Operator.GTEQ:
                    return ">=";
                case Operator.AND:
                    return "&&";
                case Operator.OR:
                    return "||";
                default:
                    return string.Empty;
            }
        }
    }


    
}
