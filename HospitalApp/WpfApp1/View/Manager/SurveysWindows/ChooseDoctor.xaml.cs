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
using Controller;
using WpfApp1.Model;

namespace WpfApp1.View.Manager.SurveysWindows
{
    /// <summary>
    /// Interaction logic for ChooseDoctor.xaml
    /// </summary>
    public partial class ChooseDoctor : Window
    {
        public ObservableCollection<Physician> Doctors { get; set; }
        public static Physician SelectedDoctor { get; set; }
        private PhysicianController doctorController = new PhysicianController();
        public ChooseDoctor()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.Manual;
            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            double height = System.Windows.SystemParameters.PrimaryScreenHeight;
            Top = 0.198 * height;
            Left = 0.275 * width;
            this.DataContext = this;
            Doctors = new ObservableCollection<Physician>(doctorController.GetAll());
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ManagerHomePage.GetManagerHomePage().Content = new DoctorSurveysCategories();
            Close();
        }
    }
}
