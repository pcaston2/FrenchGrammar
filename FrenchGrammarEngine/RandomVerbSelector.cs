using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrenchGrammarEngine.Verbs;

namespace FrenchGrammarEngine
{
    public class RandomVerbSelector
    {
        static Random r = new Random();
        public static ConjugationOptions GetRandomConjugationOption()
        {
            var moods = Enum.GetValues(typeof(Mood));
            var tenses = Enum.GetValues(typeof(Tense));
            var pronouns = Enum.GetValues(typeof(Pronoun));
            var mood = (Mood)moods.GetValue(r.Next(moods.Length));
            var tense = (Tense)tenses.GetValue(r.Next(tenses.Length));
            var pronoun = (Pronoun) pronouns.GetValue(r.Next(pronouns.Length));
            return new ConjugationOptions(mood, tense, pronoun);
        }

        public static Verb GetRandomVerb()
        {
            var verbs = Verb.Verbs();
            var verbType = verbs.Keys.ToList()[r.Next(verbs.Count)];
            return Verb.GenerateVerb(verbType);
        }
    }
}
