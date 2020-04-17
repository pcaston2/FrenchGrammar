using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs
{
    public abstract class ReVerb : Verb
    {

        public override string Ending => "re";
        public override string PastParticiple => Root + "u";
        public string AlternateInfinitive => Root + "r-";

        public override PronounDictionary GetIndicativePresentTense()
        {
            return new PronounDictionary(
                        "-s",
                        "-s",
                        "-",
                        "-ons",
                        "-ez",
                        "-ent"
                        );
        }

        public override ConjugationDictionary Conjugations
        {
            get
            {
                var td = base.Conjugations;
                td.SetTense(Mood.Indicative, Tense.Future,
                    AlternateInfinitive + GetIndicativeFutureTense());
                td.SetTense(Mood.Conditional, Tense.Present,
                    AlternateInfinitive + GetIndicativeImperfectTense());
                return td;
            }
        }
    }
}
