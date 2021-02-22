using QuizApp.Helpers;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace QuizApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public static int NumberOfQuestions { get; set; }
        
        private ICommand m_startCommand;
        private QuizModel m_quizModel;
        public HomeViewModel()
        {
            m_quizModel = new QuizModel();
        }

        public ICommand StartCommand
        {
            get
            {
                return m_startCommand = new CommandHandler(() => Start(), true);
            }
        }

        public async Task Start()
        {
            if (await m_quizModel.StartQuizAsync(NumberOfQuestions))
                Console.WriteLine("Quiz has started!");
        }
    }
}
