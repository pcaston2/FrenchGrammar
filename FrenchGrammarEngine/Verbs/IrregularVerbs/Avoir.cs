using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs.IrregularVerbs
{
    public class Avoir : IrregularVerb
    {
        public override string Root => "av";
        public override string Infinitive => "avoir";

        public override string PastParticiple => "eu";

        public override PronounDictionary GetIndicativePresentTense()
        {
            return new PronounDictionary(
                "ai",
                "as",
                "a",
                "avons",
                "avez",
                "ont"
                );
        }

        public override PronounDictionary GetSubjunctivePresentTense()
        {
            return new PronounDictionary(
                "aie",
                "aies",
                "ait",
                "ayons",
                "ayez",
                "aient"
                );
        }
    }
}
