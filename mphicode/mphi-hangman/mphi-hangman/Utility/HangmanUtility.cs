using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mphi_hangman.Utility
{
    // Utility methods for the hangman front end
    public static class HangmanUtility
    {
        public const string HANGMAN_COOKIE_NAME = "hangman";
        public const string QUESTION_ID_COOKIE_NAME = "hangmanquestionid";
        public const string USED_LETTERS_COOKIE_NAME = "hangmanusedletters";
        public const string CURRENT_ATTEMPT_NUMBER_COOKIE_NAME = "hangmancurrentattempt";

        // represents a masked character
        public const char MaskAnswerCharacter = '*';

        // mask the answer from the user
        public static string MaskAnswer(string answer, char[] usedLetters)
        {
            char[] resultArray = answer.ToCharArray();
            char[] originalAnswerArray = answer.ToCharArray();

            
            for (int i = 0; i < originalAnswerArray.Length; i++)
            {
                if (!usedLetters.Contains(originalAnswerArray[i]))
                {
                    resultArray[i] = MaskAnswerCharacter; // * represents a masked character
                }
            }
            
            return new string(resultArray);
        }
        
        // starts a new game
        private static Hangman StartNewGame(System.Web.HttpContextBase httpContext)
        {
            Hangman newHangmanSession = new Hangman();

            CookieUtility.AddCookie(httpContext, HangmanUtility.HANGMAN_COOKIE_NAME, "Started");
            CookieUtility.AddCookie(httpContext, HangmanUtility.QUESTION_ID_COOKIE_NAME, newHangmanSession.Question.Id.ToString());
            CookieUtility.AddCookie(httpContext, HangmanUtility.USED_LETTERS_COOKIE_NAME, string.Empty);
            CookieUtility.AddCookie(httpContext, HangmanUtility.CURRENT_ATTEMPT_NUMBER_COOKIE_NAME, ((int)RetryEnum.Retry.One).ToString());

            return newHangmanSession;
        }

        // ends the current game
        public static void EndCurrentGame(System.Web.HttpContextBase httpContext)
        {
            if (httpContext.Request.Cookies.AllKeys.Contains(HangmanUtility.HANGMAN_COOKIE_NAME))
            {
                CookieUtility.DeleteCookie(httpContext, HangmanUtility.HANGMAN_COOKIE_NAME);
            }

            if (httpContext.Request.Cookies.AllKeys.Contains(HangmanUtility.QUESTION_ID_COOKIE_NAME))
            {
                CookieUtility.DeleteCookie(httpContext, HangmanUtility.QUESTION_ID_COOKIE_NAME);
            }

            if (httpContext.Request.Cookies.AllKeys.Contains(HangmanUtility.USED_LETTERS_COOKIE_NAME))
            {
                CookieUtility.DeleteCookie(httpContext, HangmanUtility.USED_LETTERS_COOKIE_NAME);
            }

            if (httpContext.Request.Cookies.AllKeys.Contains(HangmanUtility.CURRENT_ATTEMPT_NUMBER_COOKIE_NAME))
            {
                CookieUtility.DeleteCookie(httpContext, HangmanUtility.CURRENT_ATTEMPT_NUMBER_COOKIE_NAME);
            }
        }

        // finds an in progress game or creates a new game
        public static Hangman FindCurrentGame(System.Web.HttpContextBase httpContext)
        {
            Hangman result = null;

            // if there is no current game, so create a new one
            if (!httpContext.Request.Cookies.AllKeys.Contains(HangmanUtility.HANGMAN_COOKIE_NAME))
            {
                return StartNewGame(httpContext);
            }

            string questionIDString = CookieUtility.GetCookie(httpContext, HangmanUtility.QUESTION_ID_COOKIE_NAME);
            int questionID;
            if(!int.TryParse(questionIDString, out questionID))
            {
                throw new Exception("Unable to start game");
            }

            string usedlettersString = CookieUtility.GetCookie(httpContext, HangmanUtility.USED_LETTERS_COOKIE_NAME);
            char[] usedlettersArray = usedlettersString.ToCharArray();

            string currentAttempString = CookieUtility.GetCookie(httpContext, HangmanUtility.CURRENT_ATTEMPT_NUMBER_COOKIE_NAME);
            RetryEnum.Retry currentAttempt;
            if(!Enum.TryParse(currentAttempString, out currentAttempt) ||
                (!Enum.IsDefined(typeof(RetryEnum.Retry), currentAttempt)))
            {
                throw new Exception("Unable to start game");
            }

            result = new Hangman(Question.GetQuestionByID(questionID),
                usedlettersArray,
                currentAttempt);
            
            return result;
        }
    }
}