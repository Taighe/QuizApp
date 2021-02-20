
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("quizdb")
        {
        }
        public DbSet<QuestionModel> Questions { get; set; }
    }
}
