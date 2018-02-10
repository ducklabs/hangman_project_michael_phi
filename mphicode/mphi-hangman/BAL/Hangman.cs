using System;
using System.Collections.Generic;
using System.Text;

namespace BAL
{
    // business logic class for the hangman game
    public class Hangman
    {
        // the hang man question
        public Question Question;
        
        // represents the letters the user has selected
        public char[] UsedLetters;

        // represents the current attempt number for the user
        public RetryEnum.Retry CurrentAtemptNumber;

        public bool IsGameSuccessful;
        

        // starts a new instance of the hangman game
        public Hangman()
        {
            Question = Question.GetRandomQuestion();

            UsedLetters = new char[0];

            CurrentAtemptNumber = RetryEnum.Retry.One;

            IsGameSuccessful = false;
        }

        // creates an instance of an existing game
        public Hangman(Question question, char[] usedLetters, RetryEnum.Retry currentAtemptNumber, bool isGameSuccessful)
        {
            Question = question;
            UsedLetters = usedLetters;
            CurrentAtemptNumber = currentAtemptNumber;
            IsGameSuccessful = isGameSuccessful;
        }
    }
}
