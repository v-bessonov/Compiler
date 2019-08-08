using System;
using System.Collections.Generic;
using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast
{
    public class FunctionDefineStatement : IStatement
    {
        private  String name;
        private  List<String> argNames;
        private  IStatement body;
    
        public FunctionDefineStatement(String name, List<String> argNames, IStatement body)
        {
            this.name = name;
            this.argNames = argNames;
            this.body = body;
        }

        
        public void Execute()
        {
            Functions.Set(name, new UserDefinedFunction(argNames, body));
        }

        public override String ToString()
        {
            return $"def ({argNames}) {body}";
        }
    }
}
