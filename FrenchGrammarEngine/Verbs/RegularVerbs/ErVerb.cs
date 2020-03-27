using FrenchGrammarEngine.Verbs.IrregularVerbs;
using System;

namespace FrenchGrammarEngine.Verbs
{
    public abstract class ErVerb : Verb
    {
        public override Type Auxiliary => typeof(Avoir);

        public override string PastParticiple => Root + "é";
    }
}
