﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs
{
    public abstract class ReVerb : Verb
    {

        public override string Ending => "re";
        public override string PastParticiple => Root + 'u';

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
                    Root + "r" + GetIndicativeFutureTense());
                return td;
            }
        }
    }
}
