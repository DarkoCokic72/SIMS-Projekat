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
using Controller;
using FileHandler;
using WpfApp1.Model;
using Repo;
using Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfApp1.View.Patientt.Survey;


namespace WpfApp1.View.Patientt.PatientAppointments
{
    /// <summary>
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Window
    {
        public static Appointments AppointmentInstance;
        public static PatientExaminationAppointmentController patientAppointmentController;
       
        public ObservableCollection<PatientExaminationAppointment> Appointment { get; set; }
        public Appointments()
        {
            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            patientAppointmentController = new PatientExaminationAppointmentController();
            Appointment = new ObservableCollection<PatientExaminationAppointment>(patientAppointmentController.GetAll());
        }
        public static Appointments GetAppointments()
        {
            if (AppointmentInstance == null)
            {
                AppointmentInstance = new Appointments();

            }

            return AppointmentInstance;
        }

        public void refreshContentOfGrid()
        {
            DataGridAppointments.ItemsSource = null;
            DataGridAppointments.ItemsSource = patientAppointmentController.GetAll();

        }

        public PatientExaminationAppointment getSelectedAppointments()
        {
            return (PatientExaminationAppointment)DataGridAppointments.SelectedItem;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button New = (Button)sender;
            PatientExaminationAppointment Appointments = getSelectedAppointments();
            if (!New.Content.Equals("New") && Appointments == null)
            {
                MessageBox.Show("You need to select a row!", "Error");
                return;
            }

            if (New.Content.Equals("New"))
            {

                NewAppointment newAppointments = new NewAppointment();
                newAppointments.Show();
            }
            Button Delete = (Button)sender;
            if (Delete.Content.Equals("Delete"))
            {
           
                patientAppointmentController.Delete(Appointments.id);
                refreshContentOfGrid();

            }
            Button Edit = (Button)sender;
            if (Edit.Content.Equals("Edit"))
            {
                EditAppointment editAppointments = new EditAppointment();
                editAppointments.Show();

            }
            Button AppointmentQuest = (Button)sender;
            if (AppointmentQuest.Content.Equals("Appointment Survey"))
            {
                if (Appointments.datetimeOfAppointment < DateTime.Now)
                {
                    AppointmentSurvey appointmentSurveyWindow = new AppointmentSurvey();
                    appointmentSurveyWindow.Show();
                }
                else
                {
                    MessageBox.Show("You must first go on that appointment", "Error");
                }

            }


        }
        protected override void OnClosing(CancelEventArgs e)
        {
            AppointmentInstance = null;
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            App.CheckNotification = false;
            Login login = new Login();
            this.Close();
            login.Show();

        }

    }
}
