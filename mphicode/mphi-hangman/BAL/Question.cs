using System;
using System.Collections.Generic;
using System.Linq;

namespace BAL
{
    // Business Access Layer for a Hangman Question
    public class Question
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public string Theme { get; set; }
        public string Hint { get; set; }

        // Gets the entire list of questions 
        public static List<Question> GetQuestions()
        {
            return new List<Question>()
            {
                new Question()
                {
                    Id = 1,
                    Answer = "APPLE",
                    Theme = "Food",
                    Hint = "Helps keep the doctor away "
                },
                new Question()
                {
                    Id = 2,
                    Answer = "ORANGE",
                    Theme = "Food",
                    Hint = "Vitamin C"

                },
                new Question()
                {
                    Id = 3,
                    Answer = "RED",
                    Theme = "Color",
                    Hint = "Stop"
                },
                new Question()
                {
                    Id = 4,
                    Answer = "BLUE",
                    Theme = "Color",
                    Hint = "Water"

                },
            };
        }

        // selects a random question 
        public static Question GetRandomQuestion()
        {
            var questions = Question.GetQuestions();
            Random randNum = new Random();
            return questions[randNum.Next(questions.Count)];
        }

        // gets a question by id
        public static Question GetQuestionByID(int id)
        {
            return Question.GetQuestions().Where(item => item.Id == id).First();
        }
    }
}
