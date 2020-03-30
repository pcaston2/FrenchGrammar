namespace FrenchGrammarEngine.Verbs
{
    public abstract class IrregularVerb : Verb
    {
        public override ConjugationDictionary Terminations
        {
            get
            {
                var cd = base.Terminations;
                cd.SetTense(Mood.Subjunctive, Tense.Present,
                    GetSubjunctivePresentTense());
                return cd;
            }
        }
    }
}
