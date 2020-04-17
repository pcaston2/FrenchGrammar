using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs.IrregularVerbs
{
    public class Être : IrregularVerb
    {
        public override string Infinitive => "être";

        public override string Root => "ét";

        public override string PastParticiple => "été";

        public override string ConditionalRoot => "ser-";
        public override PronounDictionary GetIndicativePresentTense()
        {
            return new PronounDictionary(
                "suis",
                "es",
                "est",
                "sommes",
                "êtes",
                "sont"
                );
        }

        public override PronounDictionary GetSubjunctivePresentTense()
        {
            return new PronounDictionary(
                "sois",
                "sois",
                "soit",
                "soyons",
                "soyez",
                "soient"
                );
        }

        public override ConjugationDictionary Conjugations
        {
            get
            {
                var td = base.Conjugations;
                td.SetTense(Mood.Indicative, Tense.Future,
                    "ser" + GetIndicativeFutureTense());
                return td;
            }
        }
    }
}
