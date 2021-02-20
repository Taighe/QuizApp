using QuizApp.Helpers;
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
        
        private ICommand m_startCommand;
        public ICommand StartCommand
        {
            get
            {
                return m_startCommand = new CommandHandler(() => Start(), true);
            }
        }

        private void Start()
        {
            
        }
    }
}
