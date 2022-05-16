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
using WpfApp1.View.Patientt.PatientAppointments;
using WpfApp1.View.Patientt.Survey;

namespace WpfApp1.View.Patientt
{
    /// <summary>
    /// Interaction logic for PatientHomePage.xaml
    /// </summary>
    public partial class PatientHomePage : Window
    {
        public PatientHomePage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.Equals("Appointments"))
            {
                Appointments appointemntsWindow = Appointments.GetAppointments();
                appointemntsWindow.Show();
            }
            if (btn.Content.Equals("Hospital survey"))
            {
                HospitalSurvey hospitalSurveyWindow = HospitalSurvey.GetHospitalSurvey();
                hospitalSurveyWindow.Show();

            }

        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();

        }
    }
}
