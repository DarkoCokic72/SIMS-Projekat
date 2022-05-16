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

namespace WpfApp1.View.Patientt
{
    /// <summary>
    /// Interaction logic for AppointmentSurveyDoctor.xaml
    /// </summary>
    public partial class AppointmentSurveyDoctor : Window
    {
        public static AppointmentSurveyDoctor AppointmentSurveyDoctorInstance;
        public AppointmentSurveyDoctor()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public static AppointmentSurveyDoctor GetAppointmentSurveyDoctor()
        {
            if (AppointmentSurveyDoctorInstance == null)
            {
                AppointmentSurveyDoctorInstance = new AppointmentSurveyDoctor();

            }

            return AppointmentSurveyDoctorInstance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
