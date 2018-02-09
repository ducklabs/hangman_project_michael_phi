using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mphi_hangman.Models
{
    public class Question
    {
        // question id
        public int Id { get; set; }

        // the full answer
        public string Answer { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Theme")]
        // the theme
        public string Theme { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Hint")]
        // questino hint
        public string Hint { get; set; }

        public Question(BAL.Question question)
        {
            Id = question.Id;
            Answer = question.Answer;
            Theme = question.Theme;
            Hint = question.Hint;
        }

    }
}