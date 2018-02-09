using BAL;
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
        public ActionResult Index()
        {
            ViewBag.Message = "Hangman.";

            char[] alphabit = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            char[] usedLetters = { 'A', 'O', 'G' };

            RetryEnum.Retry currentAtemptNumber = RetryEnum.Retry.Three;

            var gameViewModel = new GameViewModel()
            {
                Alphabit = alphabit,
                UsedLetters = usedLetters,
                CurrentAtemptNumber = currentAtemptNumber
            };
            
            return View(gameViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}