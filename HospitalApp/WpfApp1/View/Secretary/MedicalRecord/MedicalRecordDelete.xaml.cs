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
using WpfApp1.Model;

namespace WpfApp1
{

    public partial class MedicalRecordDelete : Window
    {
        public MedicalRecordDelete()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            if (btn.Content.Equals("No"))
            {
                Close();
            }
            else if (btn.Content.Equals("Yes"))
            {
                MedicalRecord medicalRecord = MedicalRecordWindow.medicalRecordWindowInstance.getSelectedMedicalRecord();
                MedicalRecordWindow.GetMedicalRecordWindow().medicalRecordController.Remove(medicalRecord.RegNum);

                MedicalRecordWindow.medicalRecordWindowInstance.refreshContentOfGrid();
                Close();

            }

        }
    }
}
