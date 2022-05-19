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

namespace WpfApp1.View.Physiciann.Medications
{
    /// <summary>
    /// Interaction logic for MedicationDetails.xaml
    /// </summary>
    public partial class MedicationDetails : Window
    {
        public static MedicationDetails instance;
        public MedicationDetails()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Ingredients.Text = MedicationView.SelectedDrug.Ingredients;
          
            Replacement.Text = MedicationView.SelectedDrug.Replacement;
            
            Quantity.Text = MedicationView.SelectedDrug.Quantity.ToString();
        }

        public static MedicationDetails getInstance()
        {
            if(instance == null)
            {
                instance = new MedicationDetails();
            }

            return instance;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            instance = null;
            Close();
        }
    }
}
