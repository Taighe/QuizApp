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
        public int Score { get; private set; }
        public List<QuestionModel> Quiz{ get; private set; }
        public QuizModel()
        {
            Score = 0;
        }

        public void StartQuiz(int numberofquestions)
        {
            var repo = new QuizRepository(new DataContext());
            var t = Task.Run(async () =>
            {
                return await repo.GenerateQuiz(numberofquestions);
            });

            Quiz = t.Result.ToList();
        }

        public void ScoreQuestion(QuestionModel question)
        {
            int option = question.OptionModel.ToList().IndexOf(question.OptionModel.Where(o => o.Choice == true).FirstOrDefault());
            if (question.Answer == option)
                Score++;
        }
    }
}
