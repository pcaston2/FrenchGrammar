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
                td.SetTense(Mood.Indicative, Tense.Present,
                    new PronounDictionary(
                        "-s",
                        "-s",
                        "-",
                        "-ons",
                        "-ez",
                        "-ent"
                        ));

                td.SetTense(Mood.Indicative, Tense.Imperfect,
                    GetIndicativeImperfectTense());
                
                td.SetTense(Mood.Subjunctive, Tense.Present,
                    GetSubjunctivePresentTense().Augment(GetIndicativePresentTense()));
                return td;
            }
        }
    }
}
