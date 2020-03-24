using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs
{
    public abstract class IrVerb : Verb
    {
        public override ConguationDictionary Terminations
        {
            get
            {
                ConguationDictionary td = new ConguationDictionary();
                td.AddTense(Mood.Indicative, Tense.Present,
                    new PronounDictionary(
                    "-is",
                    "-is",
                    "-it",
                    "-issons",
                    "-issez",
                    "-issent"));

                td.AddTense(Mood.Indicative, Tense.Imperfect,
                    new PronounDictionary(
                        "-iss-",
                        "-iss-",
                        "-iss-",
                        "-iss-",
                        "-iss-",
                        "-iss-"
                        ).Augment(GetIndicativeImperfectTense()));

                td.AddTense(Mood.Subjunctive, Tense.Present,
                    new PronounDictionary(
                        "-isse",
                        "-isses",
                        "-isse",
                        "-issions",
                        "-issiez",
                        "-issent"));

                return td;
            }
        }

    }
}
