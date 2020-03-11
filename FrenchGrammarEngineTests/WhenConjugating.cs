using FrenchGrammarEngine.Verbs;
using System;
using FrenchGrammarEngine;
using FrenchGrammarEngineTests;
using Xunit;

namespace FrenchGrammarEngineTests {


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

        [Fact]
        public void Should_Generate_Verbs()
        {
            // Assign
            var sut = new VerbTestData();
            var count = 0;

            // Act
            foreach (var verb in sut)
            {
                count++;
            }

            // Assert
            Assert.True(count>0);
        }

        [Fact]
        public void Should_Have_Verbs()
        {

            // Assign

            // Act
            var verbs = Verb.Verbs();

            // Assert
            Assert.NotEmpty(verbs);
        }
    }
}
