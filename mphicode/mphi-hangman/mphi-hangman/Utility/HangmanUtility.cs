using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mphi_hangman.Utility
{
    // Utility methods for the hangman front end
    public static class HangmanUtility
    {
        // represents a masked character
        public const char MaskAnswerCharacter = '*';

        // mask the answer from the user
        public static string MaskAnswer(string answer, char[] usedLetters)
        {
            char[] resultArray = answer.ToCharArray();
            char[] originalAnswerArray = answer.ToCharArray();

            for (int i = 0; i < originalAnswerArray.Length; i++)
            {
                if (usedLetters.Contains(originalAnswerArray[i]))
                {
                    resultArray[i] = MaskAnswerCharacter; // * represents a masked character
                }
            }

            return new string(resultArray);
        }
    }
}