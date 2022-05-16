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
using WpfApp1.View.Patientt.Survey;
namespace WpfApp1.View.Patientt
{
    /// <summary>
    /// Interaction logic for AppointmentSurveyOrdination.xaml
    /// </summary>
    public partial class AppointmentSurveyOrdination : Window
    {
        public static AppointmentSurveyOrdination AppointmentSurveyOrdinationInstance;
        public AppointmentSurveyOrdination()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public static AppointmentSurveyOrdination GetAppointmentSurveyOrdination()
        {
            if (AppointmentSurveyOrdinationInstance == null)
            {
                AppointmentSurveyOrdinationInstance = new AppointmentSurveyOrdination();

            }

            return AppointmentSurveyOrdinationInstance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.Equals("Finish"))
            {
                AppointmentSurveyWindow appointmentSurveyWindow = AppointmentSurveyWindow.GetAppointmentSurveyWindow();
                appointmentSurveyWindow.Show();
                Close();
            }
        }
    }
}

