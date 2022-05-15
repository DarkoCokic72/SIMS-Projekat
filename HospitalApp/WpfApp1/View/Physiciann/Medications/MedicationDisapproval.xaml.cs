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
    /// Interaction logic for MedicationDisapproval.xaml
    /// </summary>
    
    public partial class MedicationDisapproval : Window
    {
        public static MedicationDisapproval instance;
        public MedicationDisapproval()
        {
            InitializeComponent();
            DataContext = this.DataContext;
        }

        public static MedicationDisapproval getInstance()
        {
            if (instance == null)
            {
                instance = new MedicationDisapproval();
            }

            return instance;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            instance = null;
            Close();
        }
    }

    
}
