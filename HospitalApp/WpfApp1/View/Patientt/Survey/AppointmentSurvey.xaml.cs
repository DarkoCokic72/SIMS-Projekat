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

namespace WpfApp1.View.Patientt.Survey
{
    /// <summary>
    /// Interaction logic for AppointmentSurvey.xaml
    /// </summary>
    public partial class AppointmentSurvey : Window
    {
        public static AppointmentSurvey AppointmentSurveyInstance;
        public AppointmentSurvey()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public static AppointmentSurvey GetAppointmentSurveyy()
        {
            if (AppointmentSurveyInstance == null)
            {
                AppointmentSurveyInstance = new AppointmentSurvey();

            }

            return AppointmentSurveyInstance;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.Equals("Doctor"))
            {
                AppointmentSurveyDoctor AppointmentSurveyDoctorWindow = AppointmentSurveyDoctor.GetAppointmentSurveyDoctor();
                AppointmentSurveyDoctorWindow.Show();
            }
            else if (btn.Content.Equals("Assistants"))
            {
                AppoinmentSurveyAssistants appoinmentSurveyAssistantsWindow = AppoinmentSurveyAssistants.GetAppoinmentSurveyAssistants();
                appoinmentSurveyAssistantsWindow.Show();
            }
            else if (btn.Content.Equals("Ordination"))
            {
                AppointmentSurveyOrdination appointmentSurveyOrdinationWindow = AppointmentSurveyOrdination.GetAppointmentSurveyOrdination();
                appointmentSurveyOrdinationWindow.Show();
            }
        }
    }
}
