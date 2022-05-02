using Model;
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
using WpfApp1.View.Physician.ExaminationAppointments;

namespace WpfApp1.View.Physiciann.ExaminationAppointments
{
    /// <summary>
    /// Interaction logic for DeleteAppointmentWindow.xaml
    /// </summary>
    public partial class DeleteAppointmentWindow : Window
    {
        public DeleteAppointmentWindow()
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
            } else if (btn.Content.Equals("Yes"))
            {
                ExaminationAppointment appointment = ExaminationAppointmentWindow.instace.GetSelectedAppointment();
                ExaminationAppointmentWindow.appointmentControler.Delete(appointment.Id);
                ExaminationAppointmentWindow.instace.RefreshContentGrid();
                Close();
            }
        }
    }
}
