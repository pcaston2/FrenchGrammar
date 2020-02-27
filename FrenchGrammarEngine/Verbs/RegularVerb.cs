﻿using System;

namespace FrenchGrammarEngine.Verbs
{
    public abstract class RegularVerb : Verb
    {
        public abstract string Root { get; }

        public string Termination(Tense tense, Pronoun pronoun)
        {
            return Terminations.GetTense(tense, pronoun);
        }

        public override string Conjugate(ConjugationOptions conjugation)
        {
            switch (conjugation.Mood)
            {
                case Mood.Indicative:

                    switch (conjugation.Tense)
                    {
                        case Tense.Present:
                            return Root + Termination(conjugation.Tense, conjugation.Pronoun);

                    }

                    break;
            }
            throw new NotImplementedException();
        }
    }
}