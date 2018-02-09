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
    // home controller for the hangman application
    public class HomeController : Controller
    {
        // displaying the hangman game
        public ActionResult Index()
        {
            ViewBag.Message = "Michael Phi's Hangman";
            
            char[] alphabit = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            Hangman currentGame = HangmanUtility.FindCurrentGame(this.ControllerContext.HttpContext);
            

            // masks the answer for the user
            currentGame.Question.Answer = HangmanUtility.MaskAnswer(currentGame.Question.Answer, currentGame.UsedLetters);

            var gameViewModel = new GameViewModel()
            {
                Question = new Models.Question(currentGame.Question), 
                Alphabit = alphabit,
                UsedLetters = currentGame.UsedLetters,
                CurrentAtemptNumber = currentGame.CurrentAtemptNumber
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
            HangmanUtility.EndCurrentGame(this.ControllerContext.HttpContext);
            return RedirectToAction("Index");
        }

        
    }
}