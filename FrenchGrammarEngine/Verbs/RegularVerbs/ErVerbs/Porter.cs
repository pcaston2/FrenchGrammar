using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs
{
    public class Porter : ErVerb
    {
        public override string Infinitive => "porter";
        public override string PastParticiple => "porté";
        public override string Root => "port";
    }
}
