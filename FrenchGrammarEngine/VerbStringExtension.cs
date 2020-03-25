using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FrenchGrammarEngine
{
    public static class VerbStringExtension
    {
        public static bool isPostfix(this String s)
        {

            if (String.IsNullOrEmpty(s))
            {
                return false;
            }
            else
            {
                return s.StartsWith('-');
            }
        }


        public static bool isPrefix(this String s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }
            else
            {
                return s.EndsWith('-');
            }
        }



        public static string Merge(this String prefix, String postfix)
        {
            if (!postfix.isPostfix())
            {
                throw new Exception($"Expected postfix but got {postfix}");
            }

            if (String.IsNullOrEmpty(prefix))
            {
                return postfix;
            }

            return prefix.StripEnd() + postfix.StripStart();
        }

        private static string StripStart(this String postfix)
        {
            if (postfix.isPostfix())
            {
                return postfix.Substring(1, postfix.Length - 1);
            }
            else
            {
                return postfix;
            }
        }

        private static string StripEnd(this String prefix) {
            if (prefix.isPrefix())
            {
                return prefix.Substring(0, prefix.Length - 1);
            }
            else
            {
                return prefix;
            }
        }
    }
}
