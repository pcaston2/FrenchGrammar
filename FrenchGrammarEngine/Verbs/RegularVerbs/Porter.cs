using System;
using System.Collections.Generic;
using System.Text;

namespace FrenchGrammarEngine.Verbs.RegularVerbs
{
    public class Porter : ErVerb
    {
        public override string Infinitive => "porter";

        public override string Root => "port";
    }
}
