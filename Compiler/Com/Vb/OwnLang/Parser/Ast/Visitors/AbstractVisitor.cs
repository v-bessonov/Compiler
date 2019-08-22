using System;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Expressions;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Statements;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Visitors
{
    public abstract class AbstractVisitor : IVisitor
    {
        public virtual void Visit(ArrayAccessExpression s)
        {
            foreach (var index in s._indices)
            {
                index.Accept(this);
            }
        }

        public void Visit(ArrayAssignmentStatement s)
        {
            s._array.Accept(this);
            s._expression.Accept(this);
        }

        public void Visit(ArrayExpression s)
        {
            foreach (var el in s._elements)
            {
                el.Accept(this);
            }
        }

        public virtual void Visit(AssignmentStatement s)
        {
            s._expression.Accept(this);
        }

        public void Visit(BinaryExpression s)
        {
            s._expr1.Accept(this);
            s._expr2.Accept(this);
        }

        public void Visit(BlockStatement s)
        {
            foreach (var st in s._statements)
            {
                st.Accept(this);
            }
        }

        public void Visit(BreakStatement s)
        {
        }

        public void Visit(ConditionalExpression s)
        {
            s._expr1.Accept(this);
            s._expr2.Accept(this);
        }

        public void Visit(ContinueStatement s)
        {
        }

        public void Visit(DoWhileStatement s)
        {
            s._condition.Accept(this);
            s._statement.Accept(this);
        }

        public void Visit(ForStatement s)
        {
            s._init.Accept(this);
            s._termination.Accept(this);
            s._increment.Accept(this);
            s._statement.Accept(this);
        }

        public virtual void Visit(FunctionDefineStatement s)
        {
            s.body.Accept(this);
        }

        public void Visit(FunctionStatement s)
        {
            s._function.Accept(this);
        }

        public void Visit(FunctionalExpression s)
        {
            foreach (var arg in s._arguments)
            {
                arg.Accept(this);
            }
        }

        public void Visit(IfStatement s)
        {
            s._expression.Accept(this);
            s._ifStatement.Accept(this);
            s._elseStatement?.Accept(this);
        }

        public void Visit(PrintStatement s)
        {
            s._expression.Accept(this);
        }

        public void Visit(ReturnStatement s)
        {
            s._expression.Accept(this);
        }

        public void Visit(UnaryExpression s)
        {
            s._expr1.Accept(this);
        }

        public void Visit(ValueExpression s)
        {
        }

        public virtual void Visit(VariableExpression s)
        {
        }

        public void Visit(WhileStatement st)
        {
            st._condition.Accept(this);
            st._statement.Accept(this);
        }

        public void Visit(NumberExpression s)
        {
        }

        public void Visit(ConstantExpression st)
        {
        }
    }
}
