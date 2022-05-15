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
using Model;
using Controller;
using System.Collections.ObjectModel;

namespace WpfApp1.View.Physiciann.Medications
{
    /// <summary>
    /// Interaction logic for MedicationView.xaml
    /// </summary>
    public partial class MedicationView : Window
    {
        public ObservableCollection<Drug> Drugs { get; set; }
        public static Drug SelectedDrug { get; set; }

        public MedicationView()
        {
            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            DrugController controller = new DrugController();
            Drugs = new ObservableCollection<Drug>(controller.GetAll());
        }

        private void Button_Click_Details(object sender, RoutedEventArgs e)
        {
            MedicationDetails.getInstance().ShowDialog();
        }
    }
}
