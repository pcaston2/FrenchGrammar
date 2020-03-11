using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrenchGrammarEngine.Verbs.RegularVerbs;

namespace FrenchGrammarEngine.Verbs
{
    public abstract class Verb : IVerb
    {
        public abstract string Infinitive { get; }
        public abstract TerminationDictionary Terminations { get; }

        public abstract string Conjugate(ConjugationOptions conjugation);

        public static Dictionary<Type, string> Verbs()
        {
            var verbs = new Dictionary<Type, string>();

            var verbTypes = new List<Type>();
            verbTypes.Add(typeof(Porter));

            foreach (var verb in verbTypes)
            {
                var verbInstance = (Verb)Activator.CreateInstance(verb);
                verbs.Add(verb, verbInstance.Infinitive);
            }

            return verbs;
        }
    }
}
