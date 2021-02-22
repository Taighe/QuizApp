using QuizApp.Data;
using QuizApp.Helpers;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace QuizApp.ViewModels
{
    public class ResultsViewModel : BaseViewModel
    {
        public string Score 
        {
            get
            {
                return QuizModel.Score + " / " + QuizModel.Count;
            }
        }

        public IEnumerable<QuestionDto> Questions
        {
            get
            {
                var dataContext = new DataContext();
                if (QuizModel.Quiz == null)
                {
                    return Task.Run(async() => { return await new QuizRepository(dataContext).GetAllQuestionsResultsAsync();}).Result;
                }

                return Task.Run(async () => { return await new QuizRepository(dataContext).GetQuestionsResultsAsync(QuizModel.Quiz); }).Result;
            }
        }

        private ICommand m_homeCommand;
        public ICommand HomeCommand
        {
            get
            {
                return m_homeCommand = new CommandHandler(() => Home(), true);
            }
        }

        private ICommand m_copyCommand;
        public ICommand CopyCommand
        {
            get
            {
                return m_copyCommand = new CommandHandler(() => Copy(), true);
            }
        }

        public ResultsViewModel()
        {
            Console.WriteLine("init");
            OnPropertyChanged(nameof(Score));
        }

        protected void Home()
        {
            Console.WriteLine("You pressed Home Command");
        }

        protected async void Copy()
        {            
            var questions = Questions;
            string copy = await Task.Run(() => 
            {
                var results = "";
                foreach (var question in questions)
                {
                    results += "Question: " + question.Question + " Answer: " + question.Answer + "\n";
                }
                return results;
            });

            Clipboard.SetText(copy, TextDataFormat.Text);
        }
    }
}
