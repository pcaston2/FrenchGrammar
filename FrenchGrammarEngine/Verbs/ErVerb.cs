namespace FrenchGrammarEngine.Verbs
{
    public abstract class ErVerb : Verb
    {


        public override ConguationDictionary Terminations
        {
            get
            {
                ConguationDictionary td = new ConguationDictionary();
                td.AddTense(Mood.Indicative, Tense.Present,
                    new PronounDictionary(
                        "-e",
                        "-es",
                        "-e",
                        "-ons",
                        "-ez",
                        "-ent"));
                td.AddTense(Mood.Indicative, Tense.Imperfect,
                    GetIndicativeImperfectTense());
                td.AddTense(Mood.Subjunctive, Tense.Present,
                    new PronounDictionary(
                        null,
                        null,
                        null,
                        "-i-",
                        "-i-",
                        null
                    ).Augment(GetIndicativePresentTense()));

                return td;
            }
        }
    }
}
