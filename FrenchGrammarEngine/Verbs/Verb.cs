using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrenchGrammarEngine.Verbs;
using FrenchGrammarEngine.Verbs.IrregularVerbs;
using FrenchGrammarEngine.Verbs.RegularVerbs.ErVerbs;
using FrenchGrammarEngine.Verbs.RegularVerbs.IrVerbs;

namespace FrenchGrammarEngine.Verbs
{
    public abstract class Verb : IVerb
    {

        public abstract string Root { get; }
        public abstract string Infinitive { get; }

        public abstract TerminationDictionary Terminations { get; }

        public string Termination(Tense tense, Pronoun pronoun)
        {
            return Terminations.GetTense(tense, pronoun);
        }

        public static Dictionary<Type, string> Verbs()
        {
            var verbs = new Dictionary<Type, string>();

            var verbTypes = new List<Type>
            {
                typeof(Porter),
                typeof(Finir),
                typeof(Aimer),
                typeof(Batir),
                typeof(Etre),
                typeof(Avoir)
            };

            foreach (var verb in verbTypes)
            {
                var verbInstance = (Verb) Activator.CreateInstance(verb);
                verbs.Add(verb, verbInstance.Infinitive);
            }

            return verbs;
        }

        public virtual string Conjugate(ConjugationOptions conjugation)
        {
            return Root + Termination(conjugation.Tense, conjugation.Pronoun);
            switch (conjugation.Mood)
            {
                case Mood.Indicative:
                    switch (conjugation.Tense)
                    {
                        case Tense.Present:
                        case Tense.Imperfect:
                            return Root + Termination(conjugation.Tense, conjugation.Pronoun);
                    }
                    break;
            }
        }

        protected virtual string ConjugateIndicativePresent(Pronoun pronoun)
        {
            throw new NotImplementedException();
        }

    }
}
