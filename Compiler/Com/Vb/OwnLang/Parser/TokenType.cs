﻿namespace Compiler.Com.Vb.OwnLang.Parser
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
        WHILE,
        FOR,
        DO,
        BREAK,
        CONTINUE,


        PLUS,
        MINUS,
        STAR,
        SLASH,
        EQ,
        EQEQ,
        EXCL,
        EXCLEQ,
        LT,
        LTEQ,
        GT,
        GTEQ,

        BAR,
        BARBAR,
        AMP,
        AMPAMP,

        LPAREN, // (
        RPAREN, // )
        LBRACE, // {
        RBRACE, // }
        COMMA, // ,

        EOF
    }
}
