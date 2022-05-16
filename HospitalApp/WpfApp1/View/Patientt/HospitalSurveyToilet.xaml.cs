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
    /// Interaction logic for HospitalSurvey.xaml
    /// </summary>
    public partial class HospitalSurveyToilet : Window
    {
        public static HospitalSurveyToilet HospitalSurveyToiletInstance;
        public HospitalSurveyToilet()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public static HospitalSurveyToilet GetHospitalSurveyToilet()
        {
            if (HospitalSurveyToiletInstance == null)
            {
                HospitalSurveyToiletInstance = new HospitalSurveyToilet();

            }

            return HospitalSurveyToiletInstance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
