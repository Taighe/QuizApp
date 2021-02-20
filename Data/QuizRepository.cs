using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data
{
    public class QuizRepository
    {
        private DataContext m_context;

        public QuizRepository(DataContext context)
        {
            m_context = context;
        }
        public async Task<IEnumerable<QuestionModel>> GenerateQuiz(int number)
        {
            List<QuestionModel> quiz = new List<QuestionModel>();
            List<QuestionModel> allQuestions = await m_context.Questions.Include(q => q.OptionModel).ToListAsync();
            for (int i = 0; i < number; i++)
            {
                Random rand = new Random();
                var pick = rand.Next(0, allQuestions.Count() - 1);
                var question = allQuestions[pick];
                quiz.Add(question);
                allQuestions.Remove(question);
            }

            return quiz;
        }

        public List<QuestionModel> GetAllQuestions()
        {
            return m_context.Questions.Include(q => q.OptionModel).ToList();
        }
    }
}
