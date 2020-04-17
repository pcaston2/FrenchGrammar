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
        public virtual string Ending { get; }
        public abstract string Root { get; }
        public virtual string ConditionalRoot { get; }
        public virtual string Infinitive => Root + Ending;
        public abstract string PastParticiple { get; }
        public virtual Type Auxiliary => typeof(Avoir);

        
        public static Dictionary<Type, string> AllVerbs()
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

        public static List<Tuple<Mood, Tense>> AllConjugations() {
            var result = new List<Tuple<Mood, Tense>>();
            result.Add(new Tuple<Mood, Tense>(Mood.Indicative, Tense.Present));
            result.Add(new Tuple<Mood, Tense>(Mood.Indicative, Tense.Imperfect));
            result.Add(new Tuple<Mood, Tense>(Mood.Indicative, Tense.Future));
            result.Add(new Tuple<Mood, Tense>(Mood.Conditional, Tense.Present));
            result.Add(new Tuple<Mood, Tense>(Mood.Subjunctive, Tense.Present));
            result.Add(new Tuple<Mood, Tense>(Mood.Imperative, Tense.None));
            return result;
        }

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
                td.SetTense(Mood.Indicative, Tense.Future,
                    Infinitive + GetIndicativeFutureTense());
                td.SetTense(Mood.Indicative, Tense.PastPerfect,
                    GetAuxiliary().GetIndicativeImperfectTense() + " " + PastParticiple);
                td.SetTense(Mood.Subjunctive, Tense.Present,
                    Root + GetSuffix() + GetSubjunctivePresentTense() + GetStandardTense());
                td.SetTense(Mood.Conditional, Tense.Present,
                    Infinitive + GetIndicativeImperfectTense());
                td.SetTense(Mood.Imperative, Tense.None,
                    Root + GetIndicativePresentTense().MoveFirstToSecondSingular().ToImperative());
                return td;
            }
        }

        public virtual PronounDictionary GetImperativeTense()
        {
            return new PronounDictionary(
                    null,
                    "-e",
                    null,
                    "-ons",
                    "-ez",
                    null
                );
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
