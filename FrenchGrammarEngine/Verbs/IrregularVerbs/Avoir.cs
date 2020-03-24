using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs.IrregularVerbs
{
    public class Avoir : IrregularVerb
    {
        public override string Root => "av";
        public override string Infinitive => "avoir";
        
        public override PronounDictionary GetIndicativePresent()
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
    }
}
