using System;
using System.Collections.Generic;
using System.Text;
using FrenchGrammarEngine.Verbs;

namespace FrenchGrammarEngine
{
    public class ConjugationDictionary : Dictionary<KeyValuePair<Mood, Tense>, PronounDictionary>
    {
        public void SetTense(Mood mood, Tense tense, PronounDictionary pronounDictionary)
        {
            var key = new KeyValuePair<Mood,Tense>(mood, tense);
            if (this.ContainsKey(key))
            {
                this[key] = pronounDictionary;
            }
            else
            {
                this.Add(key, pronounDictionary);
            }
        }

        public string GetTense(Mood mood, Tense tense, Pronoun pronoun)
        {
            PronounDictionary terminationDictionary;
            if (this.TryGetValue(new KeyValuePair<Mood, Tense>(mood, tense), out terminationDictionary))
            {
                String termination;
                if (terminationDictionary.TryGetValue(pronoun, out termination))
                {
                    return termination;
                }
                else
                {
                    throw new NotImplementedException($"Pronoun information not found for {Enum.GetName(typeof(Pronoun),pronoun)}");
                }
            }
            else
            {
                throw new NotImplementedException($"No tense information found for {Enum.GetName(typeof(Mood), mood)} {Enum.GetName(typeof(Tense),tense)}");
            }
        }
    }
}
