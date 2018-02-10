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
                CurrentAtemptNumber = currentGame.CurrentAtemptNumber,
                IsSuccessful = currentGame.IsGameSuccessful
            };
            
            return View(gameViewModel);
        }

        // post action for guessing a letter
        [HttpPost]
        public ActionResult GuessLetter(string letterSelected)
        {
            Hangman currentGame = HangmanUtility.FindCurrentGame(this.ControllerContext.HttpContext);

            if (currentGame == null)
            {
                throw new Exception("Unable to guess the letter. There is no current game");
            }

            if(letterSelected.Length == 0)
            {
                throw new Exception("Unable to guess the letter. The letter is invalid");
            }

            // if the user finished the game, return
            if (currentGame.CurrentAtemptNumber == RetryEnum.Retry.Eleven || currentGame.IsGameSuccessful)
            {
                return RedirectToAction("Index");
            }

            char characterSelected = letterSelected.ToCharArray()[0];
            // only proceed if the user has not guessed the letter
            if (!currentGame.UsedLetters.Contains(characterSelected))
            {
                // if the answer does contains that letter, increment the try count
                if (!currentGame.Question.Answer.ToCharArray().Contains(characterSelected))
                {
                    currentGame.CurrentAtemptNumber++;
                }
            }
            
            // add the new letter to the used letters array
            currentGame.UsedLetters = (new string(currentGame.UsedLetters) + letterSelected).ToCharArray();

            // see if the game is completed
            currentGame.Question.Answer = HangmanUtility.MaskAnswer(currentGame.Question.Answer, currentGame.UsedLetters);
            if (!currentGame.Question.Answer.Contains(HangmanUtility.MaskAnswerCharacter))
            {
                currentGame.IsGameSuccessful = true;
            }

            // save the new state
            HangmanUtility.UpdateCurrentGame(this.ControllerContext.HttpContext, currentGame);
            
            // reload the page
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