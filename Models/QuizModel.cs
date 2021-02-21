using QuizApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class QuizModel
    {
        public static int Score { get; private set; }
        public static int Count { get; private set; }
        private static List<QuestionModel> m_quiz;
        public static List<QuestionModel> Quiz
        { 
            get
            {
                if(m_quiz == null)
                {
                    if(m_questionDB == null)
                    {
                        var repo = new QuizRepository(new DataContext());
                        m_questionDB = repo.GetAllQuestions();
                    }

                    return m_questionDB;
                }

                return m_quiz;
            }
        }
        private static List<QuestionModel> m_questionDB;
        public QuizModel()
        {
            Score = 0;
            m_quiz = null;
        }

        public void StartQuiz(int numberofquestions)
        {
            Score = 0;
            var repo = new QuizRepository(new DataContext());
            m_quiz = repo.GenerateQuiz(numberofquestions);
            Count = m_quiz.Count;
        }

        public static void ScoreQuestion(QuestionModel question)
        {
            int option = question.OptionModel.ToList().IndexOf(question.OptionModel.Where(o => o.Choice == true).FirstOrDefault());
            if (question.Answer == option)
                Score++;
        }
    }
}
