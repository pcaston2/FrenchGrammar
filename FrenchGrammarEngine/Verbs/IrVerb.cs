using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs
{
    public abstract class IrVerb : Verb
    {
        public static PronounDictionary GetStuffix()
        {
            return new PronounDictionary(
            "-iss-",
            "-iss-",
            "-iss-",
            "-iss-",
            "-iss-",
            "-iss-"
                 );
        }

        public override ConguationDictionary Terminations
        {
            get
            {
                ConguationDictionary td = new ConguationDictionary();
                td.SetTense(Mood.Indicative, Tense.Present,
                    new PronounDictionary(
                    "-is",
                    "-is",
                    "-it",
                    "-issons",
                    "-issez",
                    "-issent"));

                td.SetTense(Mood.Indicative, Tense.Imperfect,
                    GetStuffix().Augment(GetIndicativeImperfectTense()));

                td.SetTense(Mood.Subjunctive, Tense.Present,
                    GetStuffix().Augment(GetSubjunctivePresentTense().Augment(GetIndicativePresentTense())));

                return td;
            }
        }

    }
}
