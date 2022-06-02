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

    public partial class AppointmentsWindow : Window
    {
        public static AppointmentsWindow appointmentsWindowInstance;
        public static AppointmentController appointmentController;
        public ObservableCollection<Appointment> Appointments { get; set; }
        Physician physician;
        DateTime startDate;
        DateTime endDate;

        public AppointmentsWindow(Physician physician, DateTime startDate, DateTime endDate)
        {

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            AppointmentFileHandler fileHandler = new AppointmentFileHandler();
            AppointmentRepository repository = new AppointmentRepository(fileHandler);
            AppointmentService service = new AppointmentService(repository);
            appointmentController = new AppointmentController(service);

            this.physician = physician;
            this.startDate = startDate;
            this.endDate = endDate;

            Appointments = new ObservableCollection<Appointment>(appointmentController.GetByPhysician(physician, startDate, endDate));
        }
    }
}
