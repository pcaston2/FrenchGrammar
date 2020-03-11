using System;
using System.Collections.Generic;
using System.Text;
using FrenchGrammarEngine.Verbs;

namespace FrenchGrammarEngine
{
    public class TerminationDictionary : Dictionary<Tense, Dictionary<Pronoun, string>>
    {
        public void AddTense(Tense tense, params string[] terminations)
        {
            var tenseDictionary = new Dictionary<Pronoun, string>();
            int maxIndex = (int)Pronoun.ThirdPersonPlural;
            for (var i = 0; i <= maxIndex;i++)
            {
                string currentTermination = terminations[i];
                if (!String.IsNullOrEmpty(currentTermination))
                {
                    Pronoun currentPronoun = (Pronoun) i;
                    tenseDictionary.Add(currentPronoun, currentTermination);
                }
            }
            this.Add(tense, tenseDictionary);
        }

        public string GetTense(Tense tense, Pronoun pronoun)
        {
            Dictionary<Pronoun, string> terminationDictionary;
            if (this.TryGetValue(tense, out terminationDictionary))
            {
                String termination;
                if (terminationDictionary.TryGetValue(pronoun, out termination))
                {
                    return termination;
                }
                else
                {
                    throw new Exception($"Pronoun information not found for {Enum.GetName(typeof(Pronoun),pronoun)}");
                }
            }
            else
            {
                throw new Exception($"No tense information found for {Enum.GetName(typeof(Tense),tense)}");
            }
        }
    }
}
