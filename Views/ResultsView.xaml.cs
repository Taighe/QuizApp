using QuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuizApp.Views
{
    /// <summary>
    /// Interaction logic for QuizView.xaml
    /// </summary>
    public partial class ResultsView : Page
    {
        public ResultsView()
        {
            DataContext = new ResultsViewModel();
            InitializeComponent();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/HomeView.xaml", UriKind.Relative));
        }
    }
}
