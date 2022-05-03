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
using Syncfusion.Windows.Shared;
using WpfApp1.Model;

namespace WpfApp1.View.PatientAppointments
{
    /// <summary>
    /// Interaction logic for EditAppointment.xaml
    /// </summary>
    public partial class EditAppointment : Window
    {
        public static Boolean editedAppointment = false;
        private PatientExaminationAppointment patientExaminationAppointment;


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
                    Appointments.AppointmentsInstance.refreshContentOfGrid();
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

        private void Doctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Physician selectedPerson = Doctor.SelectedItem as Physician;
            MessageBox.Show(selectedPerson.name + selectedPerson.surname, "Doctor is selected");
        }

        private void Room_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty((string)Room.SelectedItem) && s != null)
            {
                Edit.IsEnabled = true;
            }

        }
        DateTimeEdit dateTimeEdit = new DateTimeEdit();

        private void Date_PatternChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newPattern = e.NewValue;
            var oldPattern = e.OldValue;
        }

        private void Date_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        private string GetSelectedDate()
        {
            string selectedDate = Date.SelectedText;
            return selectedDate;
        }
        string s = "moze";
        public EditAppointment()
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            patientExaminationAppointment = Appointments.AppointmentsInstance.getSelectedAppointments();
            IdBinding = patientExaminationAppointment.id;
            DoctorBinding = patientExaminationAppointment.physicianName;
            DateBinding = patientExaminationAppointment.datetimeOfAppointment;
            //TimeBinding = patientExaminationAppointment.timeOfAppointment;
            RoomBinding = patientExaminationAppointment.roomId;
            //Date.DateTime = DateBinding;

            //Date.Pattern = DateTimePattern.CustomPattern;
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





            //Date.Text = DateTime.Now.ToString();
            RoomController roomController = new RoomController();
            List<Room> rooms = roomController.GetAll();
            List<string> roomsId = new List<string>();

            foreach (Room r in rooms)
            {
                roomsId.Add(r.Id);
            }

            Room.ItemsSource = roomsId;
            Edit.IsEnabled = false;

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


        }
    }
}
