using System.Collections.Generic;

namespace FrenchGrammarEngine.Verbs
{
    public interface IVerb
    {
        string Infinitive { get; }

        TerminationDictionary Terminations { get; }

        string Conjugate(ConjugationOptions conjugation);
    }
}
