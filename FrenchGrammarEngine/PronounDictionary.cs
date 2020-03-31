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

        public PronounDictionary(string fps, string sps, string tps, string fpp, string spp, string tpp) :
                this(new List<string>()
                {
                    fps, sps, tps, fpp, spp, tpp
                }
            )
        {

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
