namespace FrenchGrammarEngine.Verbs
{
    public abstract class ErVerb : Verb
    {


        public override ConguationDictionary Terminations
        {
            get
            {
                ConguationDictionary td = new ConguationDictionary();
                td.SetTense(Mood.Indicative, Tense.Present,
                    GetIndicativePresentTense());
                td.SetTense(Mood.Indicative, Tense.Imperfect,
                    GetIndicativeImperfectTense());
                td.SetTense(Mood.Subjunctive, Tense.Present,
                    GetSubjunctivePresentTense().Augment(GetIndicativePresentTense()));

                return td;
            }
        }
    }
}
