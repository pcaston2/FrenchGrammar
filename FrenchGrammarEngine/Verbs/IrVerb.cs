using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs
{
    public abstract class IrVerb : Verb
    {
        public override TerminationDictionary Terminations
        {
            get
            {
                TerminationDictionary td = new TerminationDictionary();
                td.AddTense(Tense.Present,
                    "is",
                    "is",
                    "it",
                    "issons",
                    "issez",
                    "issent"
                );
                td.AddTense(Tense.Imperfect,
                    "issais",
                    "issais",
                    "issait",
                    "issions",
                    "issiez",
                    "issaient");
                return td;
            }
        }

    }
}
