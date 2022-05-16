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
using System.Windows.Shapes;
using WpfApp1.Model;

namespace WpfApp1.View.Patientt.Survey
{
    /// <summary>
    /// Interaction logic for AppointmentSurveyWindow.xaml
    /// </summary>
    public partial class AppointmentSurveyWindow : Window
    {
        public static AppointmentSurveyWindow AppointmentSurveyWindowInstance;
        public ObservableCollection<Answer> Surveys { get; set; }
        public QuestionnaireControlAppointment questionnaireControlAppointment { get; set; }
        public AppointmentSurveyWindow()
        {
            InitializeComponent();
            Surveys = new ObservableCollection<Answer>();
        }

        public static AppointmentSurveyWindow GetAppointmentSurveyWindow()
        {
            if (AppointmentSurveyWindowInstance == null)
            {
                AppointmentSurveyWindowInstance = new AppointmentSurveyWindow();

            }

            return AppointmentSurveyWindowInstance;
        }
    }
}
