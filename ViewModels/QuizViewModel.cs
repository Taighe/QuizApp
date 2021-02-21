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

namespace QuizApp.ViewModels
{
    public class QuizViewModel : BaseViewModel
    {
        public string Question 
        {
            get
            {
                var i = Math.Min(m_questionIndex, m_quiz.Count - 1); 
                return m_quiz[i].Question;
            } 
        }
        public IEnumerable<OptionModel> Options 
        { 
            get
            {
                return m_quiz[m_questionIndex].OptionModel;
            }
        }

        public string QuizCount 
        {
            get
            {
                return "Question " + (m_questionIndex + 1) + " / " + m_quiz.Count;
            }
        }

        public Visibility Finish
        {
            get
            {
                if(m_questionIndex >= m_quiz.Count - 1)
                {
                    return Visibility.Visible;
                }

                return Visibility.Hidden;
            }
        }
        private List<QuestionModel> m_quiz;

        private int m_questionIndex = 0;
        private ICommand m_homeCommand;
        public ICommand HomeCommand
        {
            get
            {
                return m_homeCommand = new CommandHandler(() => Home(), true);
            }
        }

        private ICommand m_nextCommand;
        public ICommand NextCommand
        {
            get
            {
                return m_nextCommand = new CommandHandler(() => Next(), true);
            }
        }

        public QuizViewModel()
        {
            Console.WriteLine("init");
            m_quiz = QuizModel.Quiz;
            OnPropertyChanged(nameof(Finish));
        }

        protected void Home()
        {
            Console.WriteLine("You pressed Home Command");
        }

        protected void Next()
        {
            QuizModel.ScoreQuestion(m_quiz[m_questionIndex]);
            m_questionIndex++;
            if(m_questionIndex < m_quiz.Count)
            {
                UpdateProperties();
            }
        }

        private void UpdateProperties()
        {
            OnPropertyChanged(nameof(Question));
            OnPropertyChanged(nameof(QuizCount));
            OnPropertyChanged(nameof(Finish));
            OnPropertyChanged(nameof(Options));
        }
    }
}
