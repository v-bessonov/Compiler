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

        public IStatement Parse()
        //public List<IStatement> Parse()
        {
            //List<IStatement> result = new List<IStatement>();
            //while (!Match(TokenType.EOF))
            //{
            //    result.Add(Statement());
            //}
            //return result;
            BlockStatement result = new BlockStatement();
            while (!Match(TokenType.EOF))
            {
                result.Add(Statement());
            }
            return result;
        }

        private IStatement Block()
        {
            BlockStatement block = new BlockStatement();
            Consume(TokenType.LBRACE);
            while (!Match(TokenType.RBRACE))
            {
                block.Add(Statement());
            }
            return block;
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
            if (Match(TokenType.WHILE))
            {
                return WhileStatement();
            }
            if (Match(TokenType.DO))
            {
                return DoWhileStatement();
            }
            if (Match(TokenType.BREAK))
            {
                return new BreakStatement();
            }
            if (Match(TokenType.CONTINUE))
            {
                return new ContinueStatement();
            }
            if (Match(TokenType.RETURN))
            {
                return new ReturnStatement(Expression());
            }
            if (Match(TokenType.FOR))
            {
                return ForStatement();
            }
            if (Match(TokenType.DEF))
            {
                return FunctionDefine();
            }
            if (Get(0).Type == TokenType.WORD && Get(1).Type == TokenType.LPAREN)
            {
                return new FunctionStatement(Function());
            }
            return AssignmentStatement();
        }

        private IStatement StatementOrBlock()
        {
            if (Get(0).Type == TokenType.LBRACE) return Block();
            return Statement();
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
            IStatement ifStatement = StatementOrBlock();
            IStatement elseStatement;
            if (Match(TokenType.ELSE))
            {
                elseStatement = StatementOrBlock();
            }
            else
            {
                elseStatement = null;
            }
            return new IfStatement(condition, ifStatement, elseStatement);
        }

        private IStatement WhileStatement()
        {
            var condition = Expression();
            var statement = StatementOrBlock();
            return new WhileStatement(condition, statement);
        }

        private IStatement DoWhileStatement()
        {
            IStatement statement = StatementOrBlock();
            Consume(TokenType.WHILE);
            IExpression condition = Expression();
            return new DoWhileStatement(condition, statement);
        }

        private IStatement ForStatement()
        {
            IStatement init = AssignmentStatement();
            Consume(TokenType.COMMA);
            IExpression termination = Expression();
            Consume(TokenType.COMMA);
            IStatement increment = AssignmentStatement();
            IStatement statement = StatementOrBlock();
            return new ForStatement(init, termination, increment, statement);
        }
        private FunctionDefineStatement FunctionDefine()
        {
            var name = Consume(TokenType.WORD).Text;
            Consume(TokenType.LPAREN);
            var argNames = new List<string>();
            while (!Match(TokenType.RPAREN))
            {
                argNames.Add(Consume(TokenType.WORD).Text);
                Match(TokenType.COMMA);
            }
            var body = StatementOrBlock();
            return new FunctionDefineStatement(name, argNames, body);
        }
        private FunctionalExpression Function()
        {
            var name = Consume(TokenType.WORD).Text;
            Consume(TokenType.LPAREN);
            var function = new FunctionalExpression(name);
            while (!Match(TokenType.RPAREN))
            {
                function.AddArgument(Expression());
                Match(TokenType.COMMA);
            }
            return function;
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
            return LogicalOr();
        }

        private IExpression LogicalOr()
        {
            IExpression result = LogicalAnd();

            while (true)
            {
                if (Match(TokenType.BARBAR))
                {
                    result = new ConditionalExpression(Operator.OR, result, LogicalAnd());
                    continue;
                }
                break;
            }

            return result;
        }

        private IExpression LogicalAnd()
        {
            IExpression result = Equality();

            while (true)
            {
                if (Match(TokenType.AMPAMP))
                {
                    result = new ConditionalExpression(Operator.AND, result, Equality());
                    continue;
                }
                break;
            }

            return result;
        }

        private IExpression Equality()
        {
            IExpression result = Conditional();

            if (Match(TokenType.EQEQ))
            {
                return new ConditionalExpression(Operator.EQUALS, result, Conditional());
            }
            if (Match(TokenType.EXCLEQ))
            {
                return new ConditionalExpression(Operator.NOT_EQUALS, result, Conditional());
            }

            return result;
        }

        private IExpression Conditional()
        {
            IExpression result = Additive();

            while (true)
            {

                if (Match(TokenType.LT))
                {
                    result = new ConditionalExpression(Operator.LT, result, Additive());
                    continue;
                }
                if (Match(TokenType.LTEQ))
                {
                    result = new ConditionalExpression(Operator.LTEQ, result, Additive());
                    continue;
                }
                if (Match(TokenType.GT))
                {
                    result = new ConditionalExpression(Operator.GT, result, Additive());
                    continue;
                }
                if (Match(TokenType.GTEQ))
                {
                    result = new ConditionalExpression(Operator.GTEQ, result, Additive());
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
            if (Get(0).Type == TokenType.WORD && Get(1).Type == TokenType.LPAREN)
            {
                return Function();
            }
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
