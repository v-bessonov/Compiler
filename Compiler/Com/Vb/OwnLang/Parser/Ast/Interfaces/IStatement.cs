﻿namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces
{
    public interface IStatement : INode
    {
        void Execute();
    }
}
