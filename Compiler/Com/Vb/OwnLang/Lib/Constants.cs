using System;
using System.Collections.Generic;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Lib
{
    public sealed class Constants
    {
        private static NumberValue ZERO = new NumberValue(0);
        //private static readonly Dictionary<string, double> _consts = new Dictionary<string, double>
        //{
        //    {"PI", Math.PI },
        //    {"ПИ", Math.PI },
        //    {"E", Math.E },
        //    {"GOLDEN_RATIO", 1.618 }
        //};

        private static readonly Dictionary<string, IValue> _consts = new Dictionary<string, IValue>
        {
            {"PI", new NumberValue(Math.PI) },
            {"ПИ", new NumberValue(Math.PI )},
            {"E", new NumberValue(Math.E )},
            {"GOLDEN_RATIO", new NumberValue(1.618 )}
        };



        public static bool IsExists(string key)
        {
            return _consts.ContainsKey(key);
        }

        //public static double Get(string key)
        //{
        //    return !IsExists(key) ? 0 : _consts[key];
        //}
        public static IValue Get(string key)
        {
            return !IsExists(key) ? ZERO : _consts[key];
        }
    }
}
