using System.Collections.Generic;
using System.Text;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public sealed class Lexer
    {

        private const string OperatorChars = "+-*/()";

        private readonly TokenType[] _operatorTokens =
        {
            TokenType.PLUS, TokenType.MINUS,
            TokenType.STAR, TokenType.SLASH,
            TokenType.LPAREN, TokenType.RPAREN,
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
            while (char.IsDigit(current))
            {
                buffer.Append(current);
                current = Next();
            }
            AddToken(TokenType.NUMBER, buffer.ToString());
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
            var position = OperatorChars.IndexOf(Peek(0));
            AddToken(_operatorTokens[position]);
            Next();
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
    }
}
