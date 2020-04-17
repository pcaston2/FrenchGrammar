using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrenchGrammarEngine.Verbs;

namespace FrenchGrammarEngine
{
    public class PronounDictionary : Dictionary<Pronoun, string>
    {

        public PronounDictionary(string termination) : this(ArrayList.Repeat(termination, 6).Cast<string>().ToList())
        {

        }


        public PronounDictionary(string termination, List<Pronoun> pronouns)
        {
            foreach (var pronoun in pronouns)
            {
                this.Add(pronoun, termination);
            }
        }

        public static List<Pronoun> ImperativePronouns()
        {
            return new List<Pronoun>()
            {
                Pronoun.SecondPersonSingular,
                Pronoun.FirstPersonPlural,
                Pronoun.SecondPersonPlural
            };
        }

        public PronounDictionary(string fps, string sps, string tps, string fpp, string spp, string tpp) :
                this(new List<string>()
                {
                    fps, sps, tps, fpp, spp, tpp
                }
            )
        {

        }

        public PronounDictionary ToImperative()
        {
            var imperativePronouns = ImperativePronouns();
            var result = new PronounDictionary(this);
            foreach(var pronoun in this.Keys.ToList())
            {
                if (!imperativePronouns.Contains(pronoun))
                {
                    result.Remove(pronoun);
                }
            }
            return result;
        }

        public PronounDictionary Remove(List<Pronoun> pronouns)
        {
            var result = new PronounDictionary(this);
            foreach (var pronoun in ImperativePronouns())
            {
                result.Remove(pronoun);
            }
            return result;
        }

        public PronounDictionary Move(Pronoun from, Pronoun to)
        {
            var result = new PronounDictionary(this);
            result[to] = this[from];
            return result;
        }

        public PronounDictionary MoveFirstToSecondSingular()
        {
            return Move(Pronoun.FirstPersonSingular, Pronoun.SecondPersonSingular);
        }

        public PronounDictionary() : base()
        {

        }

        public PronounDictionary(List<string> terminations)
        {

            int maxIndex = (int)Pronoun.ThirdPersonPlural;
            for (var i = 0; i <= maxIndex; i++)
            {
                string currentTermination = terminations[i] ?? string.Empty;
                Pronoun currentPronoun = (Pronoun) i;
                this.Add(currentPronoun, currentTermination);

            }
        }

        public PronounDictionary(PronounDictionary dictionary) : base(dictionary)
        {

        }

        public static PronounDictionary operator +(PronounDictionary pd1, PronounDictionary pd2)
        {
            var result = new PronounDictionary();

            foreach (var kvp in pd1)
            {
                Pronoun p = kvp.Key;
                string prefix = kvp.Value;
                string postfix = null;
                if (pd2.TryGetValue(p, out postfix))
                {
                    result.Add(p, prefix.Merge(postfix));
                }
            }

            return result;
        }


        public static PronounDictionary operator +(PronounDictionary pd, string postfix)
        {
            var pd1 = pd;
            var pd2 = new PronounDictionary(postfix);
            return pd1 + pd2;
        }

        public static PronounDictionary operator +(string prefix, PronounDictionary pd)
        {
            var pd1 = new PronounDictionary(prefix);
            var pd2 = pd;
            return pd1 + pd2;
        }
    }
}
