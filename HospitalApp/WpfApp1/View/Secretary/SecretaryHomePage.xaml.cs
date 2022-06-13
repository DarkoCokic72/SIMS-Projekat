using Microsoft.SqlServer.Dac.Model;
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
using WpfApp1.View.Secretary;

namespace WpfApp1.View.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryHomePage.xaml
    /// </summary>
    public partial class SecretaryHomePage : Window
    {
        public SecretaryHomePage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Username.Text = Login.userAccount.Name + " " + Login.userAccount.Surname;
            Date.Text = DateTime.Now.ToString();
            //Video video = new Video();
            //video.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.Equals("PATIENTS"))
            {
                PatientsWindow patientsWindow = PatientsWindow.GetPatientsWindow();
                patientsWindow.ShowDialog();
            }
            if (btn.Content.Equals("MEDICAL RECORDS"))
            {
                MedicalRecordWindow medicalRecordWindow = MedicalRecordWindow.GetMedicalRecordWindow();
                medicalRecordWindow.ShowDialog();
            }
            if (btn.Content.Equals("GUEST ACCOUNTS"))
            {
                GuestAccountsWindow guestAccountsWindow = GuestAccountsWindow.GetGuestAccountsWindow();
                guestAccountsWindow.ShowDialog();
            }
            if (btn.Content.Equals("APPOINTMENTS"))
            {
                AppointmentWindow appointmentWindow = AppointmentWindow.GetAppointmentWindow();
                appointmentWindow.ShowDialog();
            }
            if (btn.Content.Equals("BUY EQUIPMENT"))
            {
                EquipmentPurchaseWindow equipmentPurchaseWindow = EquipmentPurchaseWindow.GetEquipmentPurchaseWindow();
                equipmentPurchaseWindow.ShowDialog();
            }
            if (btn.Content.Equals("URGENT APPOINTMENT"))
            {
                CreateUrgentAppointment createUrgentAppointment = new CreateUrgentAppointment();
                createUrgentAppointment.ShowDialog();
            }
            if (btn.Content.Equals("PHYSICIANS REPORT"))
            {
                PhysicianReport physicianReport = new PhysicianReport();
                physicianReport.ShowDialog();
            }
            if (btn.Content.Equals("HELP VIDEO"))
            {
                Video video = new Video();
                video.ShowDialog();
            }
        }
        private void Button_Profile(object sender, RoutedEventArgs e)
        {
            ChangeSecretaryProfile secretaryProfile = new ChangeSecretaryProfile();
            secretaryProfile.ShowDialog();

        }
        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            App.CheckNotification = false;
            Login login = new Login();
            this.Close();
        }

    }
}
