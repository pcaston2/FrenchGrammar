using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrenchGrammarEngine.Verbs;
using FrenchGrammarEngine.Verbs.RegularVerbs.ErVerbs;
using FrenchGrammarEngine.Verbs.RegularVerbs.IrVerbs;

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
            verbTypes.Add(typeof(Finir));
            verbTypes.Add(typeof(Aimer));
            verbTypes.Add(typeof(Batir));

            foreach (var verb in verbTypes)
            {
                var verbInstance = (Verb)Activator.CreateInstance(verb);
                verbs.Add(verb, verbInstance.Infinitive);
            }

            return verbs;
        }
    }
}
