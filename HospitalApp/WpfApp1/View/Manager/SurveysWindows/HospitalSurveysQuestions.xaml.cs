using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.Controller;
using WpfApp1.Model;

namespace WpfApp1.View.Manager.SurveysWindows
{
    /// <summary>
    /// Interaction logic for HospitalSurveysQuestions.xaml
    /// </summary>
    public partial class HospitalSurveysQuestions : UserControl
    {
        public ObservableCollection<Question> Questions { get; set; }
        public static Question SelectedQuestion { get; set; }
        public SurveysController surveysController = new SurveysController();
        public HospitalSurveysQuestions()
        {
            InitializeComponent();
            this.DataContext = this;
            User.Text = Login.userAccount.name + " " + Login.userAccount.surname;
            Questions = new ObservableCollection<Question>(HospitalSurveysCategories.SelectedSurvey.Question);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
