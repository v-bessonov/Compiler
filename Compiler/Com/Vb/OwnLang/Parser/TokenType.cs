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
        IF,
        ELSE,

        PLUS,
        MINUS,
        STAR,
        SLASH,
        EQ,
        
        LT,
        GT,

        LPAREN, // (
        RPAREN, // )

        EOF
    }
}
