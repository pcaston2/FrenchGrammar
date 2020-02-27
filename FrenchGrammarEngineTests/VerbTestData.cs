using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FrenchGrammarEngine;
using FrenchGrammarEngine.Verbs;
using FrenchGrammarEngine.Verbs.RegularVerbs;

namespace FrenchGrammarEngineTests
{
    public class VerbTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {typeof(Porter), new ConjugationOptions(Mood.Indicative, Tense.Present,Pronoun.Je), "porte"};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
