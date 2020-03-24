using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs.IrregularVerbs
{
    public class Être : IrregularVerb
    {
        public override string Infinitive => "être";

        public override string Root => "ét";


        public override PronounDictionary GetIndicativePresent()
        {
            return new PronounDictionary(
                "suis",
                "es",
                "est",
                "sommes",
                "êtes",
                "sont");
        }
    }
}
