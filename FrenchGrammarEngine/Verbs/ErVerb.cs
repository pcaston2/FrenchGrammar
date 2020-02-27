namespace FrenchGrammarEngine.Verbs
{
    public abstract class ErVerb : RegularVerb
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
                    "e",
                    "ons",
                    "ez",
                    "ent",
                    "ent"
                );
                return td;
            }
        }
    }
}
