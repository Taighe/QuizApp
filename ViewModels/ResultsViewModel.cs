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

        private IEnumerable<QuestionDto> m_questions;
        public IEnumerable<QuestionDto> Questions
        {
            get
            {
                if(m_questions == null)
                {
                    QuizRepository repo = new QuizRepository(new DataContext());
                    m_questions = repo.GetAllQuestionsResults();
                }

                return m_questions;
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

        protected void Copy()
        {
            string copy = "";
            foreach(var question in Questions)
            {
                copy += "Question: " + question.Question + " Answer: " + question.Answer + "\n";
            }

            Clipboard.SetText(copy, TextDataFormat.Text);
        }
    }
}
