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
        public static List<QuestionModel> Quiz { get; private set; }

        public QuizModel()
        {
            Console.WriteLine("QuizModel created");
            Score = 0;
            Quiz = null;
        }

        public async Task<bool> StartQuizAsync(int numberofquestions)
        {
            Score = 0;
            var repo = new QuizRepository(new DataContext());
            Quiz = await repo.GenerateQuizAsync(numberofquestions) as List<QuestionModel>;
            Count = Quiz.Count;
            Console.WriteLine("Quiz has finished generating questions");
            return true;
        }

        public static void ScoreQuestion(QuestionModel question)
        {
            int option = question.OptionModel.ToList().IndexOf(question.OptionModel.Where(o => o.Choice == true).FirstOrDefault());
            if (question.Answer == option)
                Score++;
        }
    }
}
