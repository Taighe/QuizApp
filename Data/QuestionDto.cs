using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data
{
    public class QuestionDto
    {
        public string Question { get; private set; }
        public string Answer { get; private set; }
        public QuestionDto(QuestionModel question)
        {
            Question = question.Question;
            Answer = question.OptionModel.ElementAt(question.Answer).Answer;
        }
    }
}
