using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_Quiz_Game.Model
{
    public class Question
    {
        public Question()
        {
        }

        public Question(int iD, string questionText, string correctAnswer, string imageLocation)
        {
            ID = iD;
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            ImageLocation = imageLocation;
        }

        public int ID { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public string ImageLocation { get; set; }
        public List<string> Answers { get; set; }

    }
}
