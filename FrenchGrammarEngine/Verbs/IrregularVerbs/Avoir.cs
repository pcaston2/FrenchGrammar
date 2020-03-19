using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs.IrregularVerbs
{
    public class Avoir : IrregularVerb
    {
        public override string Root => "av";
        public override string Infinitive => "avoir";

        protected override string ConjugateIndicativePresent(Pronoun pronoun)
        {
            return pronoun switch
            {
                Pronoun.FirstPersonSingular => "ai",
                Pronoun.SecondPersonSingular => "as",
                Pronoun.ThirdPersonSingular => "a",
                Pronoun.FirstPersonPlural => "avons",
                Pronoun.SecondPersonPlural => "avez",
                Pronoun.ThirdPersonPlural => "ont",
                _ => throw new NotImplementedException(),
            };
        }
    }
}
