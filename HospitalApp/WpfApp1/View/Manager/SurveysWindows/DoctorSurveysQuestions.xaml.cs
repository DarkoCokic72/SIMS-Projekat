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
    /// Interaction logic for DoctorSurveysQuestions.xaml
    /// </summary>
    public partial class DoctorSurveysQuestions : UserControl
    {
        public ObservableCollection<Question> Questions { get; set; }
        public static Question SelectedQuestion { get; set; }
        public double AverageGrade { get; set; }
        public SurveysController surveysController = new SurveysController();
        public DoctorSurveysQuestions()
        {
            InitializeComponent();
            this.DataContext = this;
            User.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            Category.Content = "Category: " + DoctorSurveysCategories.SelectedSurvey.Category;
            AverageGrade = surveysController.GetAverageGradeOfCategory(DoctorSurveysCategories.SelectedSurvey.RefersTo, DoctorSurveysCategories.SelectedSurvey.Category);
            Questions = new ObservableCollection<Question>(DoctorSurveysCategories.SelectedSurvey.Question);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.Content = new DoctorSurveysCategories();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new DoctorSurveysAnswers();
        }
    }
}
