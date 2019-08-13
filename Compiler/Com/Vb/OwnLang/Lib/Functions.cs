using System;
using System.Collections.Generic;
using Compiler.Com.Vb.OwnLang.Lib.Funcs;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Lib
{
    public class Functions
    {
        private static Dictionary<string, IFunction> _functions = new Dictionary<string, IFunction>()
        {
            {"sin", new SinFunction()},
            {"cos", new CosFunction()},
            {"echo", new EchoFunction()},
            {"newarray", new NewArrayFunction()}
        };

        
    
        public static bool IsExists(string key)
        {
            return _functions.ContainsKey(key);
        }

        public static IFunction Get(string key)
        {
            if (!IsExists(key)) throw new Exception("Unknown function " + key);
            return _functions[key];
        }

        public static void Set(String key, IFunction function)
        {
            if (!IsExists(key))
                _functions.Add(key, function);
            else
            {
                _functions[key] = function;
            }
        }
    }
}
