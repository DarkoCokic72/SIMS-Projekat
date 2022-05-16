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
    /// Interaction logic for HospitalSurveyKitchen.xaml
    /// </summary>
    public partial class HospitalSurveyKitchen : Window
    {
        public static HospitalSurveyKitchen HospitalSurveyKitchenInstance;
        public HospitalSurveyKitchen()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public static HospitalSurveyKitchen GetHospitalSurveyKitchen()
        {
            if (HospitalSurveyKitchenInstance == null)
            {
                HospitalSurveyKitchenInstance = new HospitalSurveyKitchen();

            }

            return HospitalSurveyKitchenInstance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

