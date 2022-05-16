using System;
using System.Collections.Generic;
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
using Model;
using Controller;
//using Syncfusion.Windows.Shared;
using WpfApp1.Model;



namespace WpfApp1.View.Patientt.PatientAppointments
{
    /// <summary>
    /// Interaction logic for EditAppointment.xaml
    /// </summary>
    public partial class EditAppointment : Window
    {
        public static Boolean editedAppointment = false;
        private PatientExaminationAppointment patientExaminationAppointment;
        private PatientExaminationAppointmentController appointmentController = new PatientExaminationAppointmentController();




        private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private string doctorBinding;
        public string DoctorBinding
        {
            get { return doctorBinding; }
            set
            {
                doctorBinding = value;
                OnPropertyChanged("DoctorBinding");

            }
        }
        private DateTime dateBinding;

        public DateTime DateBinding
        {
            get { return dateBinding; }
            set
            {
                dateBinding = value;
                OnPropertyChanged("DateBinding");

            }
        }
        //private DateTime timeBinding;
        //public DateTime TimeBinding
        //{
        //    get { return timeBinding; }
        //    set
        //    {
        //        timeBinding = value;
        //        OnPropertyChanged("TimeBinding");

        //    }
        //}

        private string idBinding;
        public string IdBinding
        {
            get
            {
                return idBinding;
            }
            set
            {
                idBinding = value;
                OnPropertyChanged("IdBinding");

            }
        }
        private string roomBinding;
        public string RoomBinding
        {
            get
            {
                return roomBinding;
            }
            set
            {
                roomBinding = value;
                OnPropertyChanged("RoomBinding");

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button Edit = (Button)sender;
            if (Edit.Content.Equals("Edit"))
            {
                Appointments.patientAppointmentController.Update(new PatientExaminationAppointment(IdBinding, DoctorBinding, DateBinding, RoomBinding));

                if (editedAppointment == true)
                {
                    Appointments.AppointmentInstance.refreshContentOfGrid();
                    Close();
                }
                else
                {
                    MessageBox.Show("Appointment with that ID already exists!", "Error");
                }
            }



        }


        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(IdBinding))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        //private void Doctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{ }


        //private void Room_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //}

        //private void Room_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty((string)Room.SelectedItem) &&  s!=null && !string.IsNullOrEmpty((string)Doctor.SelectedItem))
        //    {
        //        Edit.IsEnabled = true;
        //    }

        //}
       




 
        string s = "moze";
        public static List<System.DateTime> availableDate;

        public EditAppointment()
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            patientExaminationAppointment = Appointments.AppointmentInstance.getSelectedAppointments();
            IdBinding = patientExaminationAppointment.id;
            DoctorBinding = patientExaminationAppointment.physicianName;
            DateBinding = patientExaminationAppointment.datetimeOfAppointment;
            //TimeBinding = patientExaminationAppointment.timeOfAppointment;
            RoomBinding = patientExaminationAppointment.roomId;

            Date.DateTime = DateBinding;
            string id = patientExaminationAppointment.id;

            //Date.Pattern = DateTimePattern.CustomPattern;
            availableDate = appointmentController.getAvailableDate(id);
            //    Syncfusion.Windows.Controls.CalendarDateRange blackOutDays = new Syncfusion.Windows.Controls.CalendarDateRange()
            //    {
            //        Start = availableDate[0],
            //        End = availableDate[1]
            //};
            //Syncfusion.Windows.Controls.Calendar calendar = Date.DateTimeCalender as Syncfusion.Windows.Controls.Calendar;
            //foreach (DateTime d in availableDate)
            //{
            //    calendar.BlackoutDates.Add(new Syncfusion.Windows.Controls.CalendarDateRange()
            //    {
            //        Start = d,
            //        End = d
            //    }   );

            //}
            DateTime dl = DateTime.Now.AddDays(1);
            DateTime db = DateBinding;

            int day4 = DateTime.Compare(DateBinding.AddDays(-4), DateTime.Now);
            if (day4 < 0)
            {
                Date.MinDateTime = DateTime.Now;
            }
            else if (day4 == 0)
            {
                Date.MinDateTime = DateTime.Now;
            }
            else
            {
                Date.MinDateTime = DateBinding.AddDays(-4);
            }
            Date.MaxDateTime = DateBinding.AddDays(4);





            Date.Text = DateTime.Now.ToString();



            int result = DateTime.Compare(dl, db);
            if (result == 0)
            {
                s = null;
                MessageBox.Show("You are late!", "Error");
            }
            else if (result > 0)
            {
                s = null;
                MessageBox.Show("You are late!", "Error");
            }


            RoomController roomController = new RoomController();
                List<Room> rooms = roomController.GetAll();
                List<string> roomsId = new List<string>();

                foreach (Room r in rooms)
                {
                    roomsId.Add(r.Id);
                }

                // Room.ItemsSource = roomsId;
                Edit.IsEnabled = false;
                PhysicianController physicianController = new PhysicianController();
                List<Physician> physcicians = physicianController.GetAll();
                List<string> physicianName = new List<string>();

                foreach (Physician r in physcicians)
                {
                    physicianName.Add(r.name + " " + r.surname);


                }

                //Doctor.ItemsSource = physicianName;

        }
    }
}

