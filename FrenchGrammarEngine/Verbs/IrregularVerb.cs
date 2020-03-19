namespace FrenchGrammarEngine.Verbs
{
    public abstract class IrregularVerb : ErVerb
    {

        public override string Conjugate(ConjugationOptions conjugation)
        {
            switch (conjugation.Mood)
            {
                case Mood.Indicative:
                    switch (conjugation.Tense)
                    {
                        case Tense.Present:
                            return ConjugateIndicativePresent(conjugation.Pronoun);
                    }

                    break;
            }

            return base.Conjugate(conjugation);
        }
    }
}
