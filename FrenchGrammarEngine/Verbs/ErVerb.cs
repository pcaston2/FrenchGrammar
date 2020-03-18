namespace FrenchGrammarEngine.Verbs
{
    public abstract class ErVerb : Verb
    {
        public override TerminationDictionary Terminations
        {
            get
            {
                TerminationDictionary td = new TerminationDictionary();
                td.AddTense(Tense.Present,
                    "e",
                    "es",
                    "e",
                    "ons",
                    "ez",
                    "ent"
                );
                td.AddTense(Tense.Imperfect,
                    "ais",
                    "ais",
                    "ait",
                    "ions",
                    "iez",
                    "aient"
                    );
                return td;
            }
        }
    }
}
