using System.Collections.Generic;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;
using Compiler.Com.Vb.OwnLang.Parser.Ast;
using Compiler.Com.Vb.OwnLang.Parser.Ast.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Lib
{
    public class UserDefinedFunction : IFunction
    {
        private readonly List<string> _argNames;
        private readonly IStatement _body;
    
        public UserDefinedFunction(List<string> argNames, IStatement body)
        {
            _argNames = argNames;
            _body = body;
        }

        public int GetArgsCount()
        {
            return _argNames.Count;
        }

        public string GetArgsName(int index)
        {
            if (index < 0 || index >= GetArgsCount()) return string.Empty;
            return _argNames[index];
        }

        public IValue Execute(params IValue[] args)
        {
            try
            {
                _body.Execute();
                return NumberValue.ZERO;
            }
            catch (ReturnStatement rt)
            {
                return rt.GetResult();
            }
        }
    }
}
