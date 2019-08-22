using System;
using System.Collections.Generic;
using Compiler.Com.Vb.OwnLang.Lib;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Parser.Ast.Statements
{
    public class FunctionDefineStatement : IStatement
    {
        private  String name;
        private  List<String> argNames;
        public  IStatement body;
    
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
        public void Accept(IVisitor visitor) => visitor.Visit(this);
        public override string ToString()
        {
            return $"def {name}({string.Join(", ", argNames.ToArray())}) {body}";
        }
    }
}
