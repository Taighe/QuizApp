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
        public List<QuestionModel> GenerateQuiz(int number)
        {
            List<QuestionModel> quiz = new List<QuestionModel>();
            List<QuestionModel> allQuestions = m_context.Questions.Include(q => q.OptionModel).ToList();
            for (int i = 0; i < number; i++)
            {
                Random rand = new Random();
                var pick = rand.Next(0, allQuestions.Count());
                var question = allQuestions[pick];
                quiz.Add(question);
                allQuestions.Remove(question);
            }

            return quiz;
        }

        public async Task<IEnumerable<QuestionModel>> GenerateQuizAsync(int number)
        {
            List<QuestionModel> quiz = new List<QuestionModel>();
            List<QuestionModel> allQuestions = await m_context.Questions.Include(q => q.OptionModel).ToListAsync();
            return await Task.Run(() =>
            {
                for (int i = 0; i < number; i++)
                {
                    Random rand = new Random();
                    var pick = rand.Next(0, allQuestions.Count());
                    var question = allQuestions[pick];
                    quiz.Add(question);
                    allQuestions.Remove(question);
                }

                return quiz;
            });
        }

        public List<QuestionModel> GetAllQuestions()
        {
            return m_context.Questions.Include(q => q.OptionModel).ToList();
        }

        public async Task<IEnumerable<QuestionModel>> GetAllQuestionsAsync()
        {
            return await m_context.Questions.Include(q => q.OptionModel).ToListAsync();
        }

        public List<QuestionDto> GetAllQuestionsResults()
        {
            var questions = m_context.Questions.Include(q => q.OptionModel).ToList();
            List<QuestionDto> list = new List<QuestionDto>();
            foreach(var question in questions)
            {
                list.Add(new QuestionDto(question));
            }

            return list;
        }

        public async Task<IEnumerable<QuestionDto>> GetAllQuestionsResultsAsync()
        {
            var questions = await m_context.Questions.Include(q => q.OptionModel).ToListAsync();
            List<QuestionDto> list = new List<QuestionDto>();
            return await Task.Run(() =>
            {
                foreach (var question in questions)
                {
                    list.Add(new QuestionDto(question));
                }
                return list;
            });
        }

        public List<QuestionDto> GetQuestionsResults(IEnumerable<QuestionModel> questions)
        {
            List<QuestionDto> list = new List<QuestionDto>();
            foreach (var question in questions)
            {
                list.Add(new QuestionDto(question));
            }

            return list;
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestionsResultsAsync(IEnumerable<QuestionModel> questions)
        {
            List<QuestionDto> list = new List<QuestionDto>();
            return await Task.Run(() =>
            {
                foreach (var question in questions)
                {
                    list.Add(new QuestionDto(question));
                }
                return list;
            });
        }
    }
}
