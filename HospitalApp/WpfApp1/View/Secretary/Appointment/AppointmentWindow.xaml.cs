using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using Model;
using Repo;
using Service;
using WpfApp1.Model;

namespace WpfApp1
{

    public partial class AppointmentWindow : Window
    {
        public static AppointmentWindow appointmentWindowInstance;
        public static AppointmentController appointmentController;
        public ObservableCollection<Appointment> Appointments { get; set; }

        public AppointmentWindow()
        {

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            AppointmentFileHandler fileHandler = new AppointmentFileHandler();
            AppointmentRepository repository = new AppointmentRepository(fileHandler);
            AppointmentService service = new AppointmentService(repository);
            appointmentController = new AppointmentController(service);

            Appointments = new ObservableCollection<Appointment>(appointmentController.GetAll());
        }

        public static AppointmentWindow GetAppointmentWindow()
        {
            if (appointmentWindowInstance == null)
            {
                appointmentWindowInstance = new AppointmentWindow();
            }
            return appointmentWindowInstance;
        }
        public void refreshContentOfGrid()
        {
            dgAppointments.ItemsSource = null;
            dgAppointments.ItemsSource = appointmentController.GetAll();

        }

        public Appointment getSelectedAppointment()
        {
            return (Appointment)dgAppointments.SelectedItem; ;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Appointment appointment = getSelectedAppointment();
            if (!btn.Content.Equals("Create") && appointment == null)
            {
                MessageBox.Show("You need to select a row!", "Error");
                return;
            }


            if (btn.Content.Equals("Create"))
            {
                CreateAppointment createAppointment = new CreateAppointment();
                createAppointment.Show();
            }
            else if (btn.Content.Equals("Edit"))
            {

                AppointmentEdit appointmentEdit = new AppointmentEdit();
                appointmentEdit.Show();

            }
            else if (btn.Content.Equals("Delete"))
            {

                AppointmentDelete appointmentDelete = new AppointmentDelete();
                appointmentDelete.Show();
            }

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            appointmentWindowInstance = null;
        }

    }
}
