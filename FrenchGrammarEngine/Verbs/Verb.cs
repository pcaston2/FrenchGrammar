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
        //TODO: le indicatif futur
        //TODO: passé composé
        //TODO: le indicatif plus-que-parfait
        //TODO: le conditionnel present
        //TODO: le subjonctif présent


        public virtual string Ending { get; }
        public abstract string Root { get; }
        public virtual string Infinitive => Root + Ending;

        public abstract string PastParticiple { get; }

        public virtual Type Auxiliary => typeof(Avoir);

        public Verb GetAuxiliary()
        {
            return GenerateVerb(Auxiliary);
        }

        public virtual ConjugationDictionary Conjugations
        {
            get
            {
                var td = new ConjugationDictionary();
                td.SetTense(Mood.Indicative, Tense.Present,
                    Root + GetIndicativePresentTense());
                td.SetTense(Mood.Indicative, Tense.Imperfect,
                    Root + GetSuffix() + GetIndicativeImperfectTense());
                td.SetTense(Mood.Indicative, Tense.Past,
                    Root + GetAuxiliary().GetIndicativePresentTense() + " " + PastParticiple);
                td.SetTense(Mood.Subjunctive, Tense.Present,
                    Root + GetSuffix() + GetSubjunctivePresentTense() + GetStandardTense());
                return td;
            }
        }

        public string Conjugation(Mood mood, Tense tense, Pronoun pronoun)
        {
            return Conjugations.GetTense(mood, tense, pronoun);
        }


        public virtual PronounDictionary GetSuffix()
        {
            return new PronounDictionary((string)null);
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

        public PronounDictionary GetStandardTense()
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

        public virtual PronounDictionary GetIndicativePresentTense()
        {
            return GetStandardTense();
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

        public virtual PronounDictionary GetIndicativeFutureTense()
        {
            return new PronounDictionary(
                "ai",
                "as",
                "a",
                "ons",
                "ez",
                "ont"
                );
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
            return Conjugation(conjugation.Mood, conjugation.Tense, conjugation.Pronoun);
        }



    }
}
