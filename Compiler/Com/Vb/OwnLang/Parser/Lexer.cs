using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Com.Vb.OwnLang.Parser
{
    public sealed class Lexer
    {

        private const string OperatorChars = "+-*/(){}=<>!&|,";

        //private readonly TokenType[] _operatorTokens =
        //{
        //    TokenType.PLUS, TokenType.MINUS,
        //    TokenType.STAR, TokenType.SLASH,
        //    TokenType.LPAREN, TokenType.RPAREN,
        //    TokenType.EQ, TokenType.LT, TokenType.GT
        //};

        private static Dictionary<string, TokenType> OPERATORS = new Dictionary<string, TokenType>()
        {
            {"+", TokenType.PLUS },
            {"-", TokenType.MINUS },
            {"*", TokenType.STAR },
            {"/", TokenType.SLASH },
            {"(", TokenType.LPAREN },
            {")", TokenType.RPAREN },
            {"{", TokenType.LBRACE },
            {"}", TokenType.RBRACE },
            {"=", TokenType.EQ },
            {"<", TokenType.LT },
            {">", TokenType.GT },
            {",", TokenType.COMMA },

            {"!", TokenType.EXCL },
            {"&", TokenType.AMP },
            {"|", TokenType.BAR },
            {"==", TokenType.EQEQ },
            {"!=", TokenType.EXCLEQ },
            {"<=", TokenType.LTEQ },
            {">=", TokenType.GTEQ },
            {"&&", TokenType.AMPAMP },
            {"||", TokenType.BARBAR },

        };

        private readonly string _input;
        private readonly int _length;

        private readonly List<Token> _tokens;

        private int _pos;

        public Lexer(string input)
        {
            _input = input;
            _length = input.Length;

            _tokens = new List<Token>();
        }

        public List<Token> Tokenize()
        {
            while (_pos < _length)
            {
                var current = Peek(0);
                if (char.IsDigit(current)) TokenizeNumber();
                else if (char.IsLetter(current)) TokenizeWord();
                else if (current == '"') TokenizeText();
                else if (current == '#')
                {
                    Next();
                    TokenizeHexNumber();
                }
                else if (OperatorChars.IndexOf(current) != -1)
                {
                    TokenizeOperator();
                }
                else
                {
                    // whitespaces
                    Next();
                }
            }
            return _tokens;
        }


        private void TokenizeNumber()
        {
            var buffer = new StringBuilder();
            var current = Peek(0);

            while (true)
            {
                if (current == '.')
                {
                    if (buffer.ToString().IndexOf(".", StringComparison.Ordinal) != -1) throw new Exception("Invalid float number");
                }
                else if (!char.IsDigit(current))
                {
                    break;
                }
                buffer.Append(current);
                current = Next();
            }
            AddToken(TokenType.NUMBER, buffer.ToString());
        }

        private void TokenizeText()
        {
            Next();// skip "
            var buffer = new StringBuilder();
            var current = Peek(0);
            while (true)
            {
                if (current == '\\')
                {
                    current = Next();
                    switch (current)
                    {
                        case '"': current = Next(); buffer.Append('"'); continue;
                        case 'n': current = Next(); buffer.Append('\n'); continue;
                        case 't': current = Next(); buffer.Append('\t'); continue;
                    }
                    buffer.Append('\\');
                    continue;
                }
                if (current == '"') break;
                buffer.Append(current);
                current = Next();
            }
            Next(); // skip closing "

            AddToken(TokenType.TEXT, buffer.ToString());
        }

        private void TokenizeHexNumber()
        {
            var buffer = new StringBuilder();
            var current = Peek(0);
            while (char.IsDigit(current) || IsHexNumber(current))
            {
                buffer.Append(current);
                current = Next();
            }
            AddToken(TokenType.HEX_NUMBER, buffer.ToString());
        }

        private static bool IsHexNumber(char current)
        {
            return "abcdef".IndexOf(char.ToLower(current)) != -1;
        }

        private void TokenizeOperator()
        {
            //var position = OperatorChars.IndexOf(Peek(0));
            //AddToken(_operatorTokens[position]);
            //Next();

            var current = Peek(0);
            if (current == '/')
            {
                if (Peek(1) == '/')
                {
                    Next();
                    Next();
                    TokenizeComment();
                    return;
                }

                if (Peek(1) == '*')
                {
                    Next();
                    Next();
                    TokenizeMultilineComment();
                    return;
                }
            }
            var buffer = new StringBuilder();
            while (true)
            {
                var text = buffer.ToString();
                if (!OPERATORS.ContainsKey(text + current) && !string.IsNullOrWhiteSpace(text))
                {
                    AddToken(OPERATORS[text]);
                    return;
                }
                buffer.Append(current);
                current = Next();
            }
        }

        private void TokenizeWord()
        {
            var buffer = new StringBuilder();
            var current = Peek(0);
            while (true)
            {
                if (!char.IsLetterOrDigit(current) && (current != '_') && (current != '$'))
                {
                    break;
                }
                buffer.Append(current);
                current = Next();
            }

            var word = buffer.ToString();

            switch (word)
            {
                case "print": AddToken(TokenType.PRINT); break;
                case "if": AddToken(TokenType.IF); break;
                case "else": AddToken(TokenType.ELSE); break;
                case "while": AddToken(TokenType.WHILE); break;
                case "for": AddToken(TokenType.FOR); break;
                case "do": AddToken(TokenType.DO); break;
                case "break": AddToken(TokenType.BREAK); break;
                case "continue": AddToken(TokenType.CONTINUE); break;
                case "def": AddToken(TokenType.DEF); break;
                case "return": AddToken(TokenType.RETURN); break;
                default:
                    AddToken(TokenType.WORD, word);
                    break;
            }

        }

        private char Next()
        {
            _pos++;
            return Peek(0);
        }

        private char Peek(int relativePosition)
        {
            var position = _pos + relativePosition;
            return position >= _length ? '\0' : _input[position];
        }

        private void AddToken(TokenType type)
        {
            AddToken(type, string.Empty);
        }

        private void AddToken(TokenType type, string text)
        {
            _tokens.Add(new Token(type, text));
        }

        private void TokenizeComment()
        {
            var current = Peek(0);
            while ("\r\n\0".IndexOf(current) == -1)
            {
                current = Next();
            }
        }

        private void TokenizeMultilineComment()
        {
            var current = Peek(0);
            while (true)
            {
                if (current == '\0') throw new Exception("Missing close tag");
                if (current == '*' && Peek(1) == '/') break;
                current = Next();
            }
            Next(); // *
            Next(); // /
        }
    }
}
