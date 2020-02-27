using System.Collections.Generic;

namespace FrenchGrammarEngine.Verbs
{
    public interface IVerb
    {
        string Name { get; }

        TerminationDictionary Terminations { get; }

        string Conjugate(ConjugationOptions conjugation);
    }
}
