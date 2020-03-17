using System.Collections.Generic;

namespace FrenchGrammarEngine.Verbs
{
    public interface IVerb
    {
        string Infinitive { get; }

        string Conjugate(ConjugationOptions conjugation);
    }
}
