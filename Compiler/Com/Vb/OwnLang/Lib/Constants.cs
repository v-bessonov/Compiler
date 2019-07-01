using System;
using System.Collections.Generic;

namespace Compiler.Com.Vb.OwnLang.Lib
{
    public sealed class Constants
    {

        private static readonly Dictionary<string, double> _consts = new Dictionary<string, double>
        {
            {"PI", Math.PI },
            {"ПИ", Math.PI },
            {"E", Math.E },
            {"GOLDEN_RATIO", 1.618 }
        };

        

        public static bool IsExists(string key)
        {
            return _consts.ContainsKey(key);
        }

        public static double Get(string key)
        {
            return !IsExists(key) ? 0 : _consts[key];
        }
    }
}
