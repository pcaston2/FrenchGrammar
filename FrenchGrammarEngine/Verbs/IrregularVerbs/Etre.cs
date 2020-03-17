using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs.IrregularVerbs
{
    public class Etre : Verb
    {
        public override string Infinitive => "être";

        public override string Root => "êt";

        public override TerminationDictionary Terminations => throw new NotImplementedException();

        public override string Conjugate(ConjugationOptions conjugation)
        {
            switch (conjugation.Mood)
            {
                case Mood.Indicative:
                    return ConjugateIndicative(conjugation.Tense, conjugation.Pronoun);
            }
            return string.Empty;
        }

        private string ConjugateIndicative(Tense tense, Pronoun pronoun)
        {
            switch (tense)
            {
                case Tense.Present:
                    return ConjugateIndicativePresent(pronoun);
            }
            return string.Empty;
        }

        private string ConjugateIndicativePresent(Pronoun pronoun)
        {
            switch (pronoun)
            {
                case Pronoun.FirstPersonSingular:
                    return "suis";
                case Pronoun.SecondPersonSingular:
                    return "es";
                case Pronoun.ThirdPersonSingular:
                    return "est";
                case Pronoun.FirstPersonPlural:
                    return "sommes";
                case Pronoun.SecondPersonPlural:
                    return "êtes";
                case Pronoun.ThirdPersonPlural:
                    return "sont";
            }
            return string.Empty;
        }

    }
}
