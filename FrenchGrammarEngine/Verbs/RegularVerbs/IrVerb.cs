using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs
{
    public abstract class IrVerb : Verb
    {

        public override string Ending => "ir";

        public override string PastParticiple => Root + "i";

        public override PronounDictionary GetSuffix()
        {
            return new PronounDictionary("-iss-");
        }


        public override PronounDictionary GetIndicativePresentTense()
        {
                return new PronounDictionary(
                    "-is",
                    "-is",
                    "-it",
                    "-issons",
                    "-issez",
                    "-issent"
                    );
        }

    }
}
