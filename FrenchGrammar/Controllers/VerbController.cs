using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrenchGrammar.Models;
using FrenchGrammarEngine;
using FrenchGrammarEngine.Verbs;
using Microsoft.AspNetCore.Mvc;

namespace FrenchGrammar.Controllers
{
    public class VerbController : Controller
    {
        public IActionResult Index()
        {
            var currVerb = RandomVerbSelector.GetRandomVerb();
            var currOptions = RandomVerbSelector.GetRandomConjugationOption();
            var conjugation = currVerb.Conjugate(currOptions);
            VerbViewModel model = new VerbViewModel();
            model.mood = currOptions.Mood.ToString();
            model.tense = currOptions.Tense.ToString();
            //model.pronoun = currOptions.Pronoun.ToString();
            var pronounDictionary = new Dictionary<Pronoun, string>();
            pronounDictionary.Add(Pronoun.FirstPersonSingular, "je");
            pronounDictionary.Add(Pronoun.SecondPersonSingular, "tu");
            pronounDictionary.Add(Pronoun.ThirdPersonSingular, "il/elle");
            pronounDictionary.Add(Pronoun.FirstPersonPlural, "nous");
            pronounDictionary.Add(Pronoun.SecondPersonPlural, "vous");
            pronounDictionary.Add(Pronoun.ThirdPersonPlural, "ils/elles");
            model.pronoun = pronounDictionary[currOptions.Pronoun];
            model.verb = currVerb.Infinitive;
            model.conjugation = conjugation;
            return View(model);
        }
    }
}