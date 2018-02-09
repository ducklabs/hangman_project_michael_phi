using BAL;
using mphi_hangman.Utility;
using mphi_hangman.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mphi_hangman.Controllers
{
    public class HomeController : Controller
    {
        // displaying the hangman game
        public ActionResult Index()
        {
            ViewBag.Message = "Hangman.";

            char[] alphabit = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            char[] usedLetters = { 'A', 'O', 'G' };

            RetryEnum.Retry currentAtemptNumber = RetryEnum.Retry.Three;

            var questionBAL = BAL.Question.GetRandomQuestion();

            // masks the answer for the user
            questionBAL.Answer = HangmanUtility.MaskAnswer(questionBAL.Answer, usedLetters);

            var gameViewModel = new GameViewModel()
            {
                Question = new Models.Question(questionBAL),
                Alphabit = alphabit,
                UsedLetters = usedLetters,
                CurrentAtemptNumber = currentAtemptNumber
            };
            
            return View(gameViewModel);
        }

        // post action for guessing a letter
        [HttpPost]
        public ActionResult GuessLetter(string letterSelected)
        {
            return RedirectToAction("Index");
        }

        // action for a new game
        public ActionResult New()
        {
            return RedirectToAction("Index");
        }

        
    }
}