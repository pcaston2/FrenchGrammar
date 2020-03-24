﻿using System;
using System.Collections.Generic;
using System.Text;
using FrenchGrammarEngine.Verbs;

namespace FrenchGrammarEngine
{
    public class ConguationDictionary : Dictionary<KeyValuePair<Mood, Tense>, PronounDictionary>
    {
        public void AddTense(Mood mood, Tense tense, PronounDictionary tenseDictionary)
        {
            this.Add(new KeyValuePair<Mood, Tense>(mood, tense), tenseDictionary);
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
                    throw new Exception($"Pronoun information not found for {Enum.GetName(typeof(Pronoun),pronoun)}");
                }
            }
            else
            {
                throw new Exception($"No tense information found for {Enum.GetName(typeof(Mood), mood)} {Enum.GetName(typeof(Tense),tense)}");
            }
        }
    }
}