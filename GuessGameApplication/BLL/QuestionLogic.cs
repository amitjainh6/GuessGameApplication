using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GuessGameApplication.Models;

namespace GuessGameApplication.BLL
{
    public class QuestionLogic 
    {
        private List<QuestionAnimals> _list;
        private string _noAnimalFound = "Animal Not Found";

        public QuestionLogic()
        {
            _list = new List<QuestionAnimals>();
            _list.Add(new QuestionAnimals("1" ,"Is it only found in Jungle", "Lion"));
            _list.Add(new QuestionAnimals("2", "Does it roars",  "Lion"));
            _list.Add(new QuestionAnimals("3", "Is it grey in color", "Elephant"));
            _list.Add(new QuestionAnimals("4", "Is it yellow in color",  "Lion"));
            _list.Add(new QuestionAnimals("5", "Does it have a trunk",  "Elephant"));
            _list.Add(new QuestionAnimals("6", "Does it trumpets", "Elephant"));
        }

        public QuestionAnimals GetNextQuestion(string id, string boolString)
        {
            int iID = 0;
            int.TryParse(id, out iID);
            QuestionAnimals mQuestion;
            string animalFonnd = Check(boolString);
            // if we have found an animal
            if (!animalFonnd.Equals(_noAnimalFound))
            {
                mQuestion = new QuestionAnimals("answer", "You were thinking about " + animalFonnd, "");
            }
            // if we are out of question
            else if (iID == _list.Count)
            {
                mQuestion = new QuestionAnimals("answer", _noAnimalFound, "");
            }
            else
            {
                iID++;
                mQuestion = _list.FirstOrDefault(i => i.questionID == iID.ToString());                
            }
            return mQuestion;
        }

        public List<string> GetAnimals()
        {
            List<string> animals = _list.Select(i => i.animal).Distinct().ToList<string>();
            return animals;
        }

        private string Check(string boolString)
        {
            int questionAnswered = boolString.Length;
            // only check if the current anwers is true 
            if (questionAnswered > 0 && boolString[questionAnswered - 1] == '1')
            {
                // Fecth the animal that is retaletd to the current question ie. the id would match the question answered
                var animal = _list.Where(i => i.questionID == questionAnswered.ToString()).Select(i => i.animal).ToList<string>();
                // Get all the questions related to that animal
                var listQuestionID4Animal = _list.Where(i => i.animal == animal[0]).Select(i => i.questionID).ToList<string>();
                // Only do the loop if question answered is same as the last question for animal
                int intID = 0;
                int.TryParse(listQuestionID4Animal[listQuestionID4Animal.Count - 1], out intID);
                if (questionAnswered == intID)
                {
                    // check if all the questions answered as true.
                    for (int i = 0; i < listQuestionID4Animal.Count; i++)
                    {
                        int.TryParse(listQuestionID4Animal[i], out intID);
                        if (boolString[intID - 1].Equals("1"))
                            break;
                        if (i == listQuestionID4Animal.Count - 1)
                        {
                            return animal[0];
                        }
                    }
                }
            }
            return _noAnimalFound;
        }
    }
}