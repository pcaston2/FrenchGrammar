using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs
{
    public class VerbNotImplemented : Verb
    {
        public override string Root => throw new NotImplementedException();

        public override string Infinitive => throw new NotImplementedException();

        public override ConjugationDictionary Conjugations => throw new NotImplementedException();

        public override string PastParticiple => throw new NotImplementedException();
    }
}
