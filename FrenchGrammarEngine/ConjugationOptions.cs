using System;
using System.Collections.Generic;
using System.Text;
using FrenchGrammarEngine.Verbs;

namespace FrenchGrammarEngine
{
    public class ConjugationOptions
    {
        public Mood Mood;
        public Tense Tense;
        public Pronoun Pronoun;
        
        public ConjugationOptions(Mood mood, Tense tense, Pronoun pronoun)
        {
            this.Mood = mood;
            this.Tense = tense;
            this.Pronoun = pronoun;
        }
    }
}
