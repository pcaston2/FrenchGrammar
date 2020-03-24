namespace FrenchGrammarEngine.Verbs
{
    public abstract class IrregularVerb : Verb
    {
        public override ConguationDictionary Terminations
        {
            get
            {
                var td = new ConguationDictionary();
                td.AddTense(Mood.Indicative, Tense.Imperfect,
                    GetIndicativeImperfectTense());
                td.AddTense(Mood.Indicative, Tense.Present, GetIndicativePresent());
                return td;
            }
        }

        public abstract PronounDictionary GetIndicativePresent();

    }
}
