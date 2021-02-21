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
        public enum QuestionState
        {
            Nothing,
            Correct,
            Wrong
        }
        public string Question { get; private set; }
        public string Answer { get; private set; }
        public string YourAnswer { get; private set; }
        public QuestionState State { get; private set; }
        public QuestionDto(QuestionModel question)
        {
            Question = question.Question;
            Answer = question.OptionModel.ElementAt(question.Answer).Answer;
            var option = question.OptionModel.Where(c => c.Choice == true).SingleOrDefault();
            State = QuestionState.Nothing;
            if(option != null)
            {
                State = question.OptionModel.ToList().IndexOf(option) == question.Answer ? QuestionState.Correct : QuestionState.Wrong;
                YourAnswer = option.Answer;
            }
        }
    }
}
