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
using WpfApp1.View.Patientt;

namespace WpfApp1.View.Patientt.Survey
{
    /// <summary>
    /// Interaction logic for HospitalSurvey.xaml
    /// </summary>
    public partial class HospitalSurvey : Window
    {
        public static HospitalSurvey HospitalSurveyInstance;
        public HospitalSurvey()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public static HospitalSurvey GetHospitalSurvey()
        {
            if (HospitalSurveyInstance == null)
            {
                HospitalSurveyInstance = new HospitalSurvey();

            }

            return HospitalSurveyInstance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { Button btn=( Button)sender;
            if(btn.Content.Equals("Toilet") )
            {
                HospitalSurveyToilet hospitalSurveyToiletWindow = HospitalSurveyToilet.GetHospitalSurveyToilet();
                hospitalSurveyToiletWindow.Show();
            }
            else if (btn.Content.Equals("Kitchen"))
            {
                HospitalSurveyKitchen hospitalSurveyKitchentWindow = HospitalSurveyKitchen.GetHospitalSurveyKitchen();
                hospitalSurveyKitchentWindow.Show();
            }
            else if (btn.Content.Equals("Room"))
            {
                HospitalSurveyRoom hospitalSurveyRoomWindow = HospitalSurveyRoom.GetHospitalSurveyRoom();
                hospitalSurveyRoomWindow.Show();
            }
        }
    }
}
