using System;
using System.Collections.Generic;
using System.Text;
using FrenchGrammarEngine.Verbs;

namespace FrenchGrammarEngine
{
    public class PronounDictionary : Dictionary<Pronoun, string>
    {

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

        public PronounDictionary Augment(PronounDictionary pronounDictionary)
        {
            var result = new PronounDictionary();

            foreach (var kvp in this)
            {
                Pronoun p = kvp.Key;
                string prefix = kvp.Value;
                string postfix = null;
                if (pronounDictionary.TryGetValue(p, out postfix))
                {
                    result.Add(p, prefix.Merge(postfix));
                }
            }

            return result;
        }
    }
}
