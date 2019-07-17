using System;
using System.Collections.Generic;
using Compiler.Com.Vb.OwnLang.Parser.Ast;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser
{
    public class Parser
    {
        private static Token EOF = new Token(TokenType.EOF, string.Empty);

        private readonly List<Token> _tokens;
        private readonly int _size;

        private int _pos;

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
            _size = tokens.Count;
        }

        public List<IStatement> Parse()
        {
            List<IStatement> result = new List<IStatement>();
            while (!Match(TokenType.EOF))
            {
                result.Add(Statement());
            }
            return result;
        }

        private IStatement Statement()
        {
            if (Match(TokenType.PRINT))
            {
                return new PrintStatement(Expression());
            }
            if (Match(TokenType.IF))
            {
                return IfElse();
            }
            return AssignmentStatement();
        }

        private IStatement AssignmentStatement()
        {
            // WORD EQ
            var current = Get(0);
            if (Match(TokenType.WORD) && Get(0).Type == TokenType.EQ)
            {
                var variable = current.Text;
                Consume(TokenType.EQ);
                return new AssignmentStatement(variable, Expression());
            }
            throw new Exception("Unknown statement");
        }
        private IStatement IfElse()
        {
            IExpression condition = Expression();
            IStatement ifStatement = Statement();
            IStatement elseStatement;
            if (Match(TokenType.ELSE))
            {
                elseStatement = Statement();
            }
            else
            {
                elseStatement = null;
            }
            return new IfStatement(condition, ifStatement, elseStatement);
        }

        //public List<IExpression> Parse()
        //{
        //    var result = new List<IExpression>();
        //    while (!Match(TokenType.EOF))
        //    {
        //        result.Add(Expression());
        //    }
        //    return result;
        //}

        private IExpression Expression()
        {
            return Conditional();
        }

        private IExpression Conditional()
        {
            IExpression result = Additive();

            while (true)
            {
                if (Match(TokenType.EQ))
                {
                    result = new ConditionalExpression('=', result, Additive());
                    continue;
                }
                if (Match(TokenType.LT))
                {
                    result = new ConditionalExpression('<', result, Additive());
                    continue;
                }
                if (Match(TokenType.GT))
                {
                    result = new ConditionalExpression('>', result, Additive());
                    continue;
                }
                break;
            }

            return result;
        }

        private IExpression Additive()
        {
            IExpression result = Multiplicative();

            while (true)
            {
                if (Match(TokenType.PLUS))
                {
                    result = new BinaryExpression('+', result, Multiplicative());
                    continue;
                }
                if (Match(TokenType.MINUS))
                {
                    result = new BinaryExpression('-', result, Multiplicative());
                    continue;
                }
                break;
            }

            return result;
        }

        private IExpression Multiplicative()
        {
            IExpression result = Unary();

            while (true)
            {
                // 2 * 6 / 3 
                if (Match(TokenType.STAR))
                {
                    result = new BinaryExpression('*', result, Unary());
                    continue;
                }
                if (Match(TokenType.SLASH))
                {
                    result = new BinaryExpression('/', result, Unary());
                    continue;
                }
                break;
            }

            return result;
        }

        private IExpression Unary()
        {
            if (Match(TokenType.MINUS))
            {
                return new UnaryExpression('-', Primary());
            }
            if (Match(TokenType.PLUS))
            {
                return Primary();
            }
            return Primary();
        }

        private IExpression Primary()
        {
            var current = Get(0);
            //if (Match(TokenType.NUMBER))
            //{
            //    return new NumberExpression(Convert.ToDouble(current.Text));
            //}
            if (Match(TokenType.NUMBER))
            {
                return new ValueExpression(Convert.ToDouble(current.Text));
            }
            //if (Match(TokenType.HEX_NUMBER))
            //{
            //    return new NumberExpression(long.Parse(current.Text, System.Globalization.NumberStyles.HexNumber));
            //}
            if (Match(TokenType.HEX_NUMBER))
            {
                return new ValueExpression(long.Parse(current.Text, System.Globalization.NumberStyles.HexNumber));
            }
            //if (Match(TokenType.WORD))
            //{
            //    return new ConstantExpression(current.Text);
            //}
            if (Match(TokenType.WORD))
            {
                return new VariableExpression(current.Text);
            }
            if (Match(TokenType.TEXT))
            {
                return new ValueExpression(current.Text);
            }
            if (Match(TokenType.LPAREN))
            {
                var result = Expression();
                Match(TokenType.RPAREN);
                return result;
            }
            throw new Exception("Unknown expression");
        }

        private bool Match(TokenType type)
        {
            var current = Get(0);
            if (type != current.Type) return false;
            _pos++;
            return true;
        }

        private Token Consume(TokenType type)
        {
            Token current = Get(0);
            if (type != current.Type) throw new Exception($"Token {current} doesn\'t match {type}");
            _pos++;
            return current;
        }

        private Token Get(int relativePosition)
        {
            var position = _pos + relativePosition;
            return position >= _size ? EOF : _tokens[position];
        }
    }
}
