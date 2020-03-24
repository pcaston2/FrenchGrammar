using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs
{
    public abstract class ReVerb : Verb
    {
        public override ConguationDictionary Terminations
        {
            get
            {
                ConguationDictionary td = new ConguationDictionary();
                td.AddTense(Mood.Indicative, Tense.Present,
                    new PronounDictionary(
                        "-s",
                        "-s",
                        "-",
                        "-ons",
                        "-ez",
                        "-ent"
                        ));

                td.AddTense(Mood.Indicative, Tense.Imperfect,
                    GetIndicativeImperfectTense());

                return td;
            }
        }
    }
}
