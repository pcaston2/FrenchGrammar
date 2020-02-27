using FrenchGrammarEngine.Verbs;
using System;
using FrenchGrammarEngine;
using FrenchGrammarEngine.Verbs.RegularVerbs;
using Xunit;

namespace FrenchGrammarEngineTests
{
    public class WhenConjugating
    {
        [Theory]
        [ClassData(typeof(VerbTestData))]
        public void Should_Conjugate_Properly(Type v, ConjugationOptions co, string expectedConjugation)
        {
            var verb = (IVerb)Activator.CreateInstance(v);
            var result = verb.Conjugate(co);
            Assert.Equal(expectedConjugation, result);
        }
    }
}
