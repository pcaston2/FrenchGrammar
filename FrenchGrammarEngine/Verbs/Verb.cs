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

        public virtual ConguationDictionary Terminations
        {
            get
            {
                var td = new ConguationDictionary();
                td.SetTense(Mood.Indicative, Tense.Imperfect,
                    GetIndicativeImperfectTense());
                td.SetTense(Mood.Indicative, Tense.Present,
                    GetIndicativePresentTense());
                td.SetTense(Mood.Subjunctive, Tense.Present,
                    GetSubjunctivePresentTense());
                return td;
            }
        }

        public string Termination(Mood mood, Tense tense, Pronoun pronoun)
        {
            return Terminations.GetTense(mood, tense, pronoun);
        }

        public virtual PronounDictionary GetIndicativeImperfectTense()
        {
            return new PronounDictionary(
                "-ais",
                "-ais",
                "-ait",
                "-ions",
                "-iez",
                "-aient"
                );
        }

        public virtual PronounDictionary GetIndicativePresentTense()
        {
            return new PronounDictionary(

                "-e",
                "-es",
                "-e",
                "-ons",
                "-ez",
                "-ent"
                );
        }

        public virtual PronounDictionary GetSubjunctivePresentTense()
        {
            return new PronounDictionary(
                null,
                null,
                null,
                "-i-",
                "-i-",
                null);
        }

        public static Dictionary<Type, string> Verbs()
        {
            var verbs = new Dictionary<Type, string>();

            var verbTypes = new List<Type>
            {
                typeof(Porter),
                typeof(Finir),
                typeof(Aimer),
                typeof(Bâtir),
                typeof(Être),
                typeof(Avoir),
                typeof(Attendre),
                typeof(Défendre)
            };

            foreach (var verb in verbTypes)
            {
                var verbInstance = GenerateVerb(verb);
                verbs.Add(verb, verbInstance.Infinitive);
            }

            return verbs;
        }

        public static Verb GenerateVerb(Type type)
        {
            return (Verb)Activator.CreateInstance(type);
        }

        public virtual string Conjugate(ConjugationOptions conjugation)
        {
            var termination = Termination(conjugation.Mood, conjugation.Tense, conjugation.Pronoun);
            if (termination.isPostfix())
            {
                return Root.Merge(termination);
            }
            else
            {
                return termination;
            }
        }


        protected virtual string ConjugateIndicativePresent(Pronoun pronoun)
        {
            throw new NotImplementedException();
        }

    }
}
