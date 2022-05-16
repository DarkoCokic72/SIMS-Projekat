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
using WpfApp1.View.Patientt.Survey;

namespace WpfApp1.View.Patientt.Survey
{
    /// <summary>
    /// Interaction logic for SurveyWindow.xaml
    /// </summary>
    public partial class HospitalSurveyWindow : Window
    {
        public static HospitalSurveyWindow HospitalSurveyWindowInstance;
        public ObservableCollection<Answer> Surveys {get; set; }
        public QuestionnaireControl questionnaireControl { get; set; }
        public HospitalSurveyWindow()
        {
            InitializeComponent();
            Surveys = new ObservableCollection<Answer>();
        }

        public static HospitalSurveyWindow GetHospitalSurveyWindow()
        {
            if (HospitalSurveyWindowInstance == null)
            {
                HospitalSurveyWindowInstance = new HospitalSurveyWindow();

            }

            return HospitalSurveyWindowInstance;
        }

    }   
}