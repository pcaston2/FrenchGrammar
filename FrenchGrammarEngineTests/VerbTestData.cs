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
            {Columns.IndPresFpp,new ConjugationOptions(Mood.Indicative, Tense.Present, Pronoun.FirstPersonPlural) },
            {Columns.IndPresSpp, new ConjugationOptions(Mood.Indicative, Tense.Present, Pronoun.SecondPersonPlural) },
            {Columns.IndPresTpp, new ConjugationOptions(Mood.Indicative, Tense.Present, Pronoun.ThirdPersonPlural) },
            {Columns.IndImpFps,new ConjugationOptions(Mood.Indicative, Tense.Imperfect, Pronoun.FirstPersonSingular) },
            {Columns.IndImpSps,new ConjugationOptions(Mood.Indicative, Tense.Imperfect, Pronoun.FirstPersonSingular) },
            {Columns.IndImpTps, new ConjugationOptions(Mood.Indicative, Tense.Imperfect, Pronoun.ThirdPersonSingular) },
            {Columns.IndImpFpp,new ConjugationOptions(Mood.Indicative, Tense.Imperfect, Pronoun.FirstPersonPlural) },
            {Columns.IndImpSpp,new ConjugationOptions(Mood.Indicative, Tense.Imperfect, Pronoun.SecondPersonPlural) },
            {Columns.IndImpTpp, new ConjugationOptions(Mood.Indicative, Tense.Imperfect, Pronoun.ThirdPersonPlural) }

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
            IndPasTpp
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
                var type = Verb.Verbs().Where(t => t.Value == verb).Select(t => t.Key).FirstOrDefault();

                if (type != null)
                {
                    for (int i = 0; i < columns.Length; i++)
                    {
                        ConjugationOptions options;
                        Columns col = (Columns) i;
                        if (columnMap.TryGetValue(col, out options))
                        {
                            yield return new object[] {type, options, columns[i]};
                        }
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
