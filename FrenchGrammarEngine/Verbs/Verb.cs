using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs
{
    public abstract class Verb : IVerb
    {
        public abstract string Name { get; }
        public abstract TerminationDictionary Terminations { get; }

        public abstract string Conjugate(ConjugationOptions conjugation);
    }
}
