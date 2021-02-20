using Newtonsoft.Json;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data
{
    public class Seed
    {
        private const string QUIZ_PATH = "Data/QuestionSeed.json";
        public static void SeedQuestions(DataContext context)
        {
            if (context.Questions.Any())
                return;

            using (StreamReader r = new StreamReader(QUIZ_PATH))
            {
                string json = r.ReadToEnd();
                var quiz = JsonConvert.DeserializeObject<List<QuestionModel>>(json);
                foreach (var question in quiz)
                {
                    context.Questions.Add(question);
                }

                context.SaveChanges();
            }

        }

        public static void SerializeDatabase(DataContext context)
        {
            if (context.Questions.Any())
            {
                QuizRepository repo = new QuizRepository(context);
                using (StreamWriter w = new StreamWriter(QUIZ_PATH))
                {
                    string json = JsonConvert.SerializeObject(repo.GetAllQuestions());
                    w.Write(json);
                }
            }
        }
    }
}
