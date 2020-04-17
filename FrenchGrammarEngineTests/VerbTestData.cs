using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using FrenchGrammarEngine;
using FrenchGrammarEngine.Verbs;

namespace FrenchGrammarEngineTests
{
    

    public class VerbTestData : IEnumerable<object[]>
    {
        private Dictionary<Columns, ConjugationOptions> columnMap = new Dictionary<Columns, ConjugationOptions>()
        {
            {Columns.IndPresFps, new ConjugationOptions(Mood.Indicative, Tense.Present, Pronoun.FirstPersonSingular) },
            {Columns.IndPresSps, new ConjugationOptions(Mood.Indicative, Tense.Present, Pronoun.SecondPersonSingular) },
            {Columns.IndPresTps, new ConjugationOptions(Mood.Indicative,Tense.Present, Pronoun.ThirdPersonSingular) },
            {Columns.IndPresFpp, new ConjugationOptions(Mood.Indicative, Tense.Present, Pronoun.FirstPersonPlural) },
            {Columns.IndPresSpp, new ConjugationOptions(Mood.Indicative, Tense.Present, Pronoun.SecondPersonPlural) },
            {Columns.IndPresTpp, new ConjugationOptions(Mood.Indicative, Tense.Present, Pronoun.ThirdPersonPlural) },
            {Columns.IndImpFps, new ConjugationOptions(Mood.Indicative, Tense.Imperfect, Pronoun.FirstPersonSingular) },
            {Columns.IndImpSps, new ConjugationOptions(Mood.Indicative, Tense.Imperfect, Pronoun.FirstPersonSingular) },
            {Columns.IndImpTps, new ConjugationOptions(Mood.Indicative, Tense.Imperfect, Pronoun.ThirdPersonSingular) },
            {Columns.IndImpFpp, new ConjugationOptions(Mood.Indicative, Tense.Imperfect, Pronoun.FirstPersonPlural) },
            {Columns.IndImpSpp, new ConjugationOptions(Mood.Indicative, Tense.Imperfect, Pronoun.SecondPersonPlural) },
            {Columns.IndImpTpp, new ConjugationOptions(Mood.Indicative, Tense.Imperfect, Pronoun.ThirdPersonPlural) },
            {Columns.IndFutFps, new ConjugationOptions(Mood.Indicative,Tense.Future,Pronoun.FirstPersonSingular) } ,
            {Columns.IndFutSps, new ConjugationOptions(Mood.Indicative,Tense.Future,Pronoun.SecondPersonSingular) } ,
            {Columns.IndFutTps, new ConjugationOptions(Mood.Indicative,Tense.Future,Pronoun.ThirdPersonSingular) } ,
            {Columns.IndFutFpp, new ConjugationOptions(Mood.Indicative,Tense.Future,Pronoun.FirstPersonPlural) } ,
            {Columns.IndFutSpp, new ConjugationOptions(Mood.Indicative,Tense.Future,Pronoun.SecondPersonPlural) } ,
            {Columns.IndFutTpp, new ConjugationOptions(Mood.Indicative,Tense.Future,Pronoun.ThirdPersonPlural) } ,
            {Columns.IndConFps, new ConjugationOptions(Mood.Conditional,Tense.Present,Pronoun.FirstPersonSingular) } ,
            {Columns.IndConSps, new ConjugationOptions(Mood.Conditional,Tense.Present,Pronoun.SecondPersonSingular) } ,
            {Columns.IndConTps, new ConjugationOptions(Mood.Conditional,Tense.Present,Pronoun.ThirdPersonSingular) } ,
            {Columns.IndConFpp, new ConjugationOptions(Mood.Conditional,Tense.Present,Pronoun.FirstPersonPlural) } ,
            {Columns.IndConSpp, new ConjugationOptions(Mood.Conditional,Tense.Present,Pronoun.SecondPersonPlural) } ,
            {Columns.IndConTpp, new ConjugationOptions(Mood.Conditional,Tense.Present,Pronoun.ThirdPersonPlural) } ,
            {Columns.SubPresFps, new ConjugationOptions(Mood.Subjunctive,Tense.Present,Pronoun.FirstPersonSingular) } ,
            {Columns.SubPresSps, new ConjugationOptions(Mood.Subjunctive,Tense.Present,Pronoun.SecondPersonSingular) } ,
            {Columns.SubPresTps, new ConjugationOptions(Mood.Subjunctive,Tense.Present,Pronoun.ThirdPersonSingular) } ,
            {Columns.SubPresFpp, new ConjugationOptions(Mood.Subjunctive,Tense.Present,Pronoun.FirstPersonPlural) } ,
            {Columns.SubPresSpp, new ConjugationOptions(Mood.Subjunctive,Tense.Present,Pronoun.SecondPersonPlural) } ,
            {Columns.SubPresTpp, new ConjugationOptions(Mood.Subjunctive,Tense.Present,Pronoun.ThirdPersonPlural) } ,
            //{Columns.SubImpFps, new ConjugationOptions(Mood.Subjunctive,Tense.Imperfect,Pronoun.FirstPersonSingular) } ,
            //{Columns.SubImpSps, new ConjugationOptions(Mood.Subjunctive,Tense.Imperfect,Pronoun.SecondPersonSingular) } ,
            //{Columns.SubImpTps, new ConjugationOptions(Mood.Subjunctive,Tense.Imperfect,Pronoun.ThirdPersonSingular) } ,
            //{Columns.SubImpFpp, new ConjugationOptions(Mood.Subjunctive,Tense.Imperfect,Pronoun.FirstPersonPlural) } ,
            //{Columns.SubImpSpp, new ConjugationOptions(Mood.Subjunctive,Tense.Imperfect,Pronoun.SecondPersonPlural) } ,
            //{Columns.SubImpTpp, new ConjugationOptions(Mood.Subjunctive,Tense.Imperfect,Pronoun.ThirdPersonPlural) } ,
            {Columns.ImpFps, new ConjugationOptions(Mood.Imperative,Tense.None,Pronoun.FirstPersonSingular) } ,
            {Columns.ImpSps, new ConjugationOptions(Mood.Imperative,Tense.None,Pronoun.SecondPersonSingular) } ,
            {Columns.ImpTps, new ConjugationOptions(Mood.Imperative,Tense.None,Pronoun.ThirdPersonSingular) } ,
            {Columns.ImpFpp, new ConjugationOptions(Mood.Imperative,Tense.None,Pronoun.FirstPersonPlural) } ,
            {Columns.ImpSpp, new ConjugationOptions(Mood.Imperative,Tense.None,Pronoun.SecondPersonPlural) } ,
            {Columns.ImpTpp, new ConjugationOptions(Mood.Imperative,Tense.None,Pronoun.ThirdPersonPlural) }
        };
        enum Columns
        {
            Infinitive,
            Gerund,
            PresentParticiple,
            PastParticiple,
            CompoundVerb,
            IndPresFps,
            IndPresSps,
            IndPresTps,
            IndPresFpp,
            IndPresSpp,
            IndPresTpp,
            IndImpFps,
            IndImpSps,
            IndImpTps,
            IndImpFpp,
            IndImpSpp,
            IndImpTpp,
            IndPasFps,
            IndPasSps,
            IndPasTps,
            IndPasFpp,
            IndPasSpp,
            IndPasTpp,
            IndFutFps,
            IndFutSps,
            IndFutTps,
            IndFutFpp,
            IndFutSpp,
            IndFutTpp,
            IndConFps,
            IndConSps,
            IndConTps,
            IndConFpp,
            IndConSpp,
            IndConTpp, 
            SubPresFps,
            SubPresSps,
            SubPresTps,
            SubPresFpp,
            SubPresSpp,
            SubPresTpp,
            SubImpFps,
            SubImpSps,
            SubImpTps,
            SubImpFpp,
            SubImpSpp,
            SubImpTpp,
            ImpFps,
            ImpSps,
            ImpTps,
            ImpFpp,
            ImpSpp,
            ImpTpp
        }

        public List<KeyValuePair<Mood, Tense>> CommonTenses()
        {
            return new List<KeyValuePair<Mood, Tense>>()
            {
                new KeyValuePair<Mood, Tense>(Mood.Indicative, Tense.Present),
                new KeyValuePair<Mood, Tense>(Mood.Subjunctive, Tense.Imperfect)
            };
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"conjugationdataset.csv");
            var lines = File.ReadAllLines(path);
            var header = true;
            foreach (var line in lines)
            {
                if (header)
                {
                    header = false;
                    continue;
                }

                var columns = line.Split(',');
                var verb = columns[(int) Columns.Infinitive];
                var type = Verb.AllVerbs().Where(t => t.Value == verb).Select(t => t.Key).FirstOrDefault();

                if (type != null)
                {
                    for (int i = 0; i < columns.Length; i++)
                    {
                        ConjugationOptions options;
                        Columns col = (Columns) i;
                        var expectedConjugation = columns[i];
                        if (!String.IsNullOrEmpty(expectedConjugation)) {
                            if (columnMap.TryGetValue(col, out options))
                            {
                                yield return new object[] { type, options, expectedConjugation };
                            }
                        }
                    }
                }
                else
                {
                    //yield return new object[] {typeof(VerbNotImplemented),null,columns[0]};
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
