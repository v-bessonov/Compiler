namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public sealed class Token
    {
        public TokenType Type { get;  set; }
        public string Text { get;  set; }

        public Token()
        {
        }

        public Token(TokenType type, string text)
        {
            Type = type;
            Text = text;
        }
        
        public override string ToString()
        {
            return $"{Type} {Text}";
        }
    }
}
