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
    /// Interaction logic for HospitalSurveyRoom.xaml
    /// </summary>
    public partial class HospitalSurveyRoom : Window
    {
        public static HospitalSurveyRoom HospitalSurveyRoomInstance;
        public HospitalSurveyRoom()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public static HospitalSurveyRoom GetHospitalSurveyRoom()
        {
            if (HospitalSurveyRoomInstance == null)
            {
                HospitalSurveyRoomInstance = new HospitalSurveyRoom();

            }

            return HospitalSurveyRoomInstance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.Equals("Finish"))
            {
                SurveyWindow SurveyWindowWindow = SurveyWindow.GetSurveyWindow();
                SurveyWindowWindow.Show();
            }
        }
    }
}
