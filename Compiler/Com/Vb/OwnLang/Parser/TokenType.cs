namespace Compiler.Com.Vb.OwnLang.Parser
{
    public enum TokenType
    {

        NUMBER,
        HEX_NUMBER,
        WORD,
        TEXT,

        // keyword
        PRINT,

        PLUS,
        MINUS,
        STAR,
        SLASH,
        EQ,

        LPAREN, // (
        RPAREN, // )

        EOF
    }
}
