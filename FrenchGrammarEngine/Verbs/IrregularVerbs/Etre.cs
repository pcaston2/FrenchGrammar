using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs.IrregularVerbs
{
    public class Etre : IrregularVerb
    {
        public override string Infinitive => "être";

        public override string Root => "ét";


        protected override string ConjugateIndicativePresent(Pronoun pronoun)
        {
            return pronoun switch
            {
                Pronoun.FirstPersonSingular => "suis",
                Pronoun.SecondPersonSingular => "es",
                Pronoun.ThirdPersonSingular => "est",
                Pronoun.FirstPersonPlural => "sommes",
                Pronoun.SecondPersonPlural => "êtes",
                Pronoun.ThirdPersonPlural => "sont",
                _ => throw new NotImplementedException(),
            };
        }

    }
}
