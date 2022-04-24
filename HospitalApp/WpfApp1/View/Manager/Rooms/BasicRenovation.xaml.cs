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
using Model;
using Repo;
using Service;
using WpfApp1.Controller;
using WpfApp1.FileHandler;

namespace WpfApp1.View.Manager.Rooms
{
    /// <summary>
    /// Interaction logic for BasicRenovation.xaml
    /// </summary>
    public partial class BasicRenovation : Window
    {
        public static List<System.DateTime> SelectedDates { get; set; }
        private List<System.DateTime> dates;
        private string roomId;
        private string description;
        public BasicRenovation(string _roomId,string _description)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.DataContext = this.
            roomId = _roomId;
            description = _description;

            ExaminationAppointmentFileHandler examinationAppointmentFileHandler = new ExaminationAppointmentFileHandler();
            ExaminationAppointmentRepository examinationAppointmentRepository = new ExaminationAppointmentRepository(examinationAppointmentFileHandler);
            ExaminationAppointmentService examinationAppointmentService = new ExaminationAppointmentService(examinationAppointmentRepository);
            ExaminationAppointmentControler examinationAppointmentController = new ExaminationAppointmentControler(examinationAppointmentService);

            List<ExaminationAppointment> appointments = examinationAppointmentController.GetAll();

            foreach(ExaminationAppointment e in appointments) {
                Calendar.BlackoutDates.Add(new CalendarDateRange(e.DateOfAppointment, e.DateOfAppointment));
            }

            SelectedDates = new List<System.DateTime>();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_Schedule(object sender, RoutedEventArgs e)
        {
            dates = new List<System.DateTime>((IEnumerable<DateTime>)List.ItemsSource);
            RoomController roomController = new RoomController();
            roomController.SchedulingRenovation(new Model.Renovation(roomId, description, dates[0], dates[dates.Count - 1]));
            Close();
        }

    }
}
