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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuizApp.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        public HomeView()
        {
            DataContext = new HomeViewModel();
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/QuizView.xaml", UriKind.Relative));
        }

        private void Results_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/ResultsView.xaml", UriKind.Relative));

        }
    }
}
