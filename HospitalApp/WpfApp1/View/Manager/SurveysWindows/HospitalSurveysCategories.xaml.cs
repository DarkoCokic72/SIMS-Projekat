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
    /// Interaction logic for HospitalSurveysCategories.xaml
    /// </summary>
    public partial class HospitalSurveysCategories : UserControl
    {
        public ObservableCollection<Survey> Surveys { get; set; }
        public double AverageGrade { get; set; }
        public static Survey SelectedSurvey { get; set; }
        public SurveysController surveysController = new SurveysController();
        public HospitalSurveysCategories()
        {
            InitializeComponent();
            this.DataContext = this;
            User.Text = Login.userAccount.name + " " + Login.userAccount.surname;
            AverageGrade = surveysController.GetAverageGradeOfHospital();
            Surveys = new ObservableCollection<Survey>(surveysController.GetAllForHospital());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            this.Content = new Login();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Content = new ManagerHomePage();
        }

        private void Button_Click_Questions(object sender, RoutedEventArgs e)
        {

        }
    }
}
