using System;
using System.Collections.Generic;
using System.Text;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Statements
{
    public class BlockStatement : IStatement
    {
        public readonly List<IStatement> _statements;

        public BlockStatement()
        {
            _statements = new List<IStatement>();
        }

        public void Add(IStatement statement)
        {
            _statements.Add(statement);
        }

        
        public void Execute()
        {
            foreach (var statement in _statements)
            {
                statement.Execute();
            }

        }
        public void Accept(IVisitor visitor) => visitor.Visit(this);

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var statement in _statements)
            {
                result.AppendFormat("{0}{1}", statement.ToString(), Environment.NewLine);
            }
            return result.ToString();
        }
    }
}
