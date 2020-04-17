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
            var conjugations = Verb.AllConjugations();
            var conjugation = conjugations[r.Next(conjugations.Count)];
            var pronouns = Enum.GetValues(typeof(Pronoun)).Cast<Pronoun>().ToList();
            var mood = conjugation.Item1;
            var tense = conjugation.Item2;
            if (mood == Mood.Imperative)
            {
                pronouns = PronounDictionary.ImperativePronouns();
            }
            var pronoun = (Pronoun) pronouns[r.Next(pronouns.Count)];
            return new ConjugationOptions(mood, tense, pronoun);
        }

        public static Verb GetRandomVerb()
        {
            var verbs = Verb.AllVerbs();
            var verbType = verbs.Keys.ToList()[r.Next(verbs.Count)];
            return Verb.GenerateVerb(verbType);
        }
    }
}
