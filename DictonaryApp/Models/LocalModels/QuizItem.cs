using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictonaryApp.Models.LocalModels
{
    public class QuizItem
    {
        public int Score = 1;
        public required string Answer;
        public required string Question;
        public bool IsAnsweredCorrectrly = false;
        public required string AnswerLanguage;
        public required string QuestionLanguage;
    }
}
