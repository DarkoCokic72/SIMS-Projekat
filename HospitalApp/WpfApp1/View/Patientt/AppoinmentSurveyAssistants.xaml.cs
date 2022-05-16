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
    /// Interaction logic for AppoinmentSurveyAssistants.xaml
    /// </summary>
    public partial class AppoinmentSurveyAssistants : Window
    {
        public static AppoinmentSurveyAssistants AppoinmentSurveyAssistantsInstance;
        public AppoinmentSurveyAssistants()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public static AppoinmentSurveyAssistants GetAppoinmentSurveyAssistants()
        {
            if (AppoinmentSurveyAssistantsInstance == null)
            {
                AppoinmentSurveyAssistantsInstance = new AppoinmentSurveyAssistants();

            }

            return AppoinmentSurveyAssistantsInstance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
