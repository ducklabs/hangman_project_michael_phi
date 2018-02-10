using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mphi_hangman.ViewModel
{
    // View Model for the game 
    public class GameViewModel
    {
        // the hang man question
        public Models.Question Question;
        
        // represents the letters from A-Z
        public char[] Alphabit;
        
        // represents the letters the user has selected
        public char[] UsedLetters;

        // represents the current attempt number for the user
        public RetryEnum.Retry CurrentAtemptNumber;

        // represents whether the user successfully completed the game
        public bool IsSuccessful;
    }
}