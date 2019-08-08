using System;
using System.Collections.Generic;
using Compiler.Com.Vb.OwnLang.Lib.Interfaces;

namespace Compiler.Com.Vb.OwnLang.Lib
{
    public class Variables
    {
        private static  NumberValue ZERO = new NumberValue(0);
        private static  Stack<Dictionary<String, IValue>> stack = new Stack<Dictionary<string, IValue>>();
        //private static readonly Dictionary<string, double> _variables = new Dictionary<string, double>
        //{
        //    {"PI", Math.PI },
        //    {"ПИ", Math.PI },
        //    {"E", Math.E },
        //    {"GOLDEN_RATIO", 1.618 }
        //};

        public static void Push()
        {
            stack.Push(new Dictionary<String, IValue>(_variables));
        }

        public static void Pop()
        {
            _variables = stack.Pop();
        }

        private static Dictionary<string, IValue> _variables = new Dictionary<string, IValue>
        {
            {"PI", new NumberValue(Math.PI)},
            {"ПИ", new NumberValue(Math.PI )},
            {"E", new NumberValue(Math.E) },
            {"GOLDEN_RATIO", new NumberValue(1.618) }
        };


        public static bool IsExists(string key)
        {
            return _variables.ContainsKey(key);
        }

        //public static double Get(string key)
        //{
        //    return !IsExists(key) ? 0 : _variables[key];
        //}
        public static IValue Get(string key)
        {
            return !IsExists(key) ? ZERO : _variables[key];
        }

        //public static void Set(string key, double value)
        //{
        //    _variables.Add(key, value);
        //}

        public static void Set(string key, IValue value)
        {
            if (!IsExists(key))
                _variables.Add(key, value);
            else
            {
                _variables[key] = value;
            }

        }
    }

}
