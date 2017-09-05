using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessGameApplication.Models
{
    public class QuestionAnimals 
    {
        public string questionID { get; set; }
        public string question { get; set; }
        public string animal { get; set; }

        public QuestionAnimals (string id, string question, string animal)
        {
            questionID = id;
            this.question = question;
            this.animal = animal;
        }
    }
}