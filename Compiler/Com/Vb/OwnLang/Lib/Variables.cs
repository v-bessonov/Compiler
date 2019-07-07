using System;
using System.Collections.Generic;

namespace Compiler.Com.Vb.OwnLang.Lib
{
    public class Variables
    {
        private static readonly Dictionary<string, double> _variables = new Dictionary<string, double>
        {
            {"PI", Math.PI },
            {"ПИ", Math.PI },
            {"E", Math.E },
            {"GOLDEN_RATIO", 1.618 }
        };



        public static bool IsExists(string key)
        {
            return _variables.ContainsKey(key);
        }

        public static double Get(string key)
        {
            return !IsExists(key) ? 0 : _variables[key];
        }

        public static void Set(string key, double value)
        {
            _variables.Add(key, value);
        }
    }

}
