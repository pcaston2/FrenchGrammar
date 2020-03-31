namespace FrenchGrammarEngine.Verbs
{
    public abstract class IrregularVerb : Verb
    {
        public virtual string FutureRoot { get; }

        public override ConjugationDictionary Conjugations
        {
            get
            {
                var cd = base.Conjugations;
                cd.SetTense(Mood.Indicative, Tense.Present,
                    GetIndicativePresentTense());
                cd.SetTense(Mood.Subjunctive, Tense.Present,
                    GetSubjunctivePresentTense());
                return cd;
            }
        }
    }
}
