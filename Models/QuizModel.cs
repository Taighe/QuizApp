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
        public List<QuestionModel> Quiz{ get; private set; }
        public QuizModel()
        {
            Score = 0;
        }

        public QuizModel( int y, int i = 0)
        {
            Score = 0;
        }

        public void StartQuiz(int numberofquestions)
        {
            Score = 0;
            var repo = new QuizRepository(new DataContext());
            var t = Task.Run(async () =>
            {
                return await repo.GenerateQuiz(numberofquestions);
            });

            Quiz = t.Result.ToList();
            Count = Quiz.Count;
        }

        public void ScoreQuestion(QuestionModel question)
        {
            int option = question.OptionModel.ToList().IndexOf(question.OptionModel.Where(o => o.Choice == true).FirstOrDefault());
            if (question.Answer == option)
                Score++;
        }
    }
}
